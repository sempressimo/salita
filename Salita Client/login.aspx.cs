using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.txtUsername.Focus();
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SalitaEntities db = new SalitaEntities();

                var U = db.Users.SingleOrDefault(p => p.Username == this.txtUsername.Value && p.UserPassword == this.txtPassword.Text);

                if (U != null)
                {
                    Session["Username"] = U.Username;
                    Session["Role"] = U.Role;

                    HttpCookie cookie = FormsAuthentication.GetAuthCookie(this.txtUsername.Value, false);
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);

                    // Store UserData inside the Forms Ticket with all the attributes
                    // in sync with the web.config
                    var newticket = new FormsAuthenticationTicket(ticket.Version,
                                                                  ticket.Name,
                                                                  ticket.IssueDate,
                                                                  ticket.Expiration,
                                                                  false, // always persistent
                                                                  "admin",
                                                                  ticket.CookiePath);

                    // Encrypt the ticket and store it in the cookie
                    cookie.Value = FormsAuthentication.Encrypt(newticket);
                    cookie.Expires = newticket.Expiration.AddHours(24);
                    this.Context.Response.Cookies.Set(cookie);

                    if (Session["Role"].ToString() == "D")
                    {
                        Response.Redirect("transport_page.aspx");
                    }
                    else
                    {
                        Response.Redirect("default.aspx");
                    }
                }
                else
                {
                    SalitaEntities db2 = new SalitaEntities();

                    DateTime From = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00AM");
                    DateTime To = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 11:59PM");

                    //var C = db2.v_RecentVisits.SingleOrDefault(p => p.VisitDate >= From && p.VisitDate <= To && p.Phone == this.txtUsername.Text && this.txtPassword.Text.Trim() == p.LoginPIN);
                    var C = db2.v_RecentVisits.SingleOrDefault(p => p.Phone == this.txtUsername.Value && this.txtPassword.Text.Trim() == p.LoginPIN);

                    if (C != null)
                    {
                        Session["Username"] = C.FullName;
                        Session["Role"] = "C";
                        Session["Customer_ID"] = C.Customer_ID;

                        HttpCookie cookie = FormsAuthentication.GetAuthCookie(this.txtUsername.Value, false);
                        var ticket = FormsAuthentication.Decrypt(cookie.Value);

                        // Store UserData inside the Forms Ticket with all the attributes
                        // in sync with the web.config
                        var newticket = new FormsAuthenticationTicket(ticket.Version,
                                                                      ticket.Name,
                                                                      ticket.IssueDate,
                                                                      ticket.Expiration,
                                                                      false, // persistent
                                                                      "customer",
                                                                      ticket.CookiePath);

                        // Encrypt the ticket and store it in the cookie
                        cookie.Value = FormsAuthentication.Encrypt(newticket);
                        //cookie.Expires = newticket.Expiration.AddHours(24);
                        this.Context.Response.Cookies.Set(cookie);

                        Response.Redirect(@"\CustomerHome\default.aspx");
                    }
                    else
                    {
                        this.CustomValidator1.IsValid = false;
                        this.CustomValidator1.ErrorMessage = "Incorrect username or password.";
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;

                if (E.InnerException != null)
                {
                    this.CustomValidator1.ErrorMessage += " Inner exception: " + E.InnerException.Message;
                }
            }
        }
    }
}
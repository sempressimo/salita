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
            this.txtUsername.Focus();
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SalitaEntities db = new SalitaEntities();

                var U = db.Users.SingleOrDefault(p => p.Username == this.txtUsername.Text && p.UserPassword == this.txtPassword.Text);

                if (U != null)
                {
                    Session["Username"] = U.Username;
                    Session["Role"] = U.Role;

                    FormsAuthentication.SetAuthCookie(this.txtUsername.Text, false);

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

                    var C = db2.v_RecentVisits.SingleOrDefault(p => p.VisitDate >= From && p.VisitDate <= To && p.Phone == this.txtUsername.Text && this.txtPassword.Text.Trim() == p.LoginPIN);

                    if (C != null)
                    {
                        Session["Username"] = C.FullName;
                        Session["Role"] = "C";

                        FormsAuthentication.SetAuthCookie(this.txtUsername.Text, false);

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
            }
        }
    }
}
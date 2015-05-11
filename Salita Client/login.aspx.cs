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

        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SalitaEntities db = new SalitaEntities();

                var U = db.Users.SingleOrDefault(p => p.Username == this.txtUsername.Text && p.UserPassword == this.txtPassword.Text);

                if (U != null)
                {
                    Session["Username"] = U.Username;
                    Session["Role"] = U.Role;
 
                    FormsAuthentication.RedirectFromLoginPage(this.txtUsername.Text, false);
                }
                else
                {
                    SalitaEntities db2 = new SalitaEntities();

                    var C = db2.v_RecentVisits.Where(p => p.Phone == this.txtUsername.Text && this.txtPassword.Text == "1234");

                    if (C != null)
                    {
                        Session["Username"] = U.Username;
                        Session["Role"] = "C";

                        FormsAuthentication.SetAuthCookie(this.txtUsername.Text, false);

                        Response.Redirect("customer_default.aspx");
                    }
                    else
                    {
                        this.CustomValidator1.IsValid = false;
                        this.CustomValidator1.ErrorMessage = "Incorrect username or password.";
                    }
                }
            }
            catch(Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
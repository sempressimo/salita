using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbSalita_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void lbCustomers_Click(object sender, EventArgs e)
        {
            Response.Redirect("customers_list.aspx");
        }

        protected void lbReportServices_Click(object sender, EventArgs e)
        {
            Response.Redirect("report_services.aspx");
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void lbReportTransportation_Click(object sender, EventArgs e)
        {
            Response.Redirect("report_transportation.aspx");
        }

        protected void lbUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("login_list.aspx");
        }
    }
}
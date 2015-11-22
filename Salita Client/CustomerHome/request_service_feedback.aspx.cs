using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client.CustomerHome
{
    public partial class request_service_feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbOK_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}
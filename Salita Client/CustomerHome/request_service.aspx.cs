using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client.CustomerHome
{
    public partial class request_service : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SalitaEntities db = new SalitaEntities();

                DateTime from = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00AM");
                DateTime to = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 11:59PM");

                int cid = Convert.ToInt32(Session["Customer_ID"]);

                var myNeeds = db.CustomerNeeds.Where(p => p.RequestDateTime >= from && p.RequestDateTime <= to && p.Customer_ID == cid && p.WasFullfilled == false);

                foreach (CustomerNeed need in myNeeds)
                {
                    if (need.RequestedService_ID == 1)
                    {
                        water_alert.Visible = true;
                        this.lbGetWater.Enabled = false;
                        this.Water_Text.Visible = false;
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbGetWater_Click(object sender, EventArgs e)
        {
            ViewState["sid"] = Request.QueryString["sid"];
            ViewState["note"] = Request.QueryString["n"];

            Response.Redirect("service_request_confirmation.aspx?cid=" + Session["Customer_ID"].ToString() + "&sid=1&n=Botella fria.");
        }
    }
}
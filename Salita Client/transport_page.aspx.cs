using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class transport_page : System.Web.UI.Page
    {
        SalitaEntities db = new SalitaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.li_llevar.Attributes.Remove("class");
                this.li_recojer.Attributes.Remove("class");

                if (Request.QueryString["m"] == "recojer")
                {
                    this.li_recojer.Attributes.Add("class", "btn btn-primary");
                    
                    this.LoadRecords(this.lvTake, false);
                }
                else
                {
                    this.li_llevar.Attributes.Add("class", "btn btn-primary");

                    this.LoadRecords(this.lvTake, true);
                }

                this.CountTransports();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void RegisterJQuery(string JQuery)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "JQuery", "<script type='text/javascript'>$(function(){" + JQuery + "});</script>", false);
        }

        protected void CountTransports()
        {
            DateTime from = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00AM");
            DateTime to = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 11:59PM");

            var R = db.v_CustomerNeeds.Where(p => p.WasFullfilled == false && p.RequestDateTime >= from && p.RequestDateTime <= to && (p.RequestedService_ID == 3 || p.RequestedService_ID == 4)).OrderBy(p => p.RequestDateTime).OrderBy(p => p.WasFullfilled);

            this.lblTake.Text = R.Where(p => p.FromDealer == true).Count().ToString();
            this.lblPickUp.Text = R.Where(p => p.FromDealer == false).Count().ToString();
        }

        protected void LoadRecords(ListView gv, Boolean FromDealer)
        {
            DateTime from = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00AM");
            DateTime to = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 11:59PM");

            IQueryable<v_CustomerNeeds> R = null;

            R = db.v_CustomerNeeds.Where(p => p.FromDealer == FromDealer && p.WasFullfilled == false && p.RequestDateTime >= from && p.RequestDateTime <= to && (p.RequestedService_ID == 3 || p.RequestedService_ID == 4)).OrderBy(p => p.RequestDateTime).OrderBy(p => p.RequestDateTime);
            
            gv.DataSource = R.ToList();
            gv.DataBind();

        }

        protected void lbComplete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandArgument;

            Response.Redirect("service_complete.aspx?id=" + id);
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandArgument;

            Response.Redirect("cancel_transportation.aspx?id=" + id);
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandArgument;

            Response.Redirect("address.aspx?id=" + id);
        }
    }
}
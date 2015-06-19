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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.LoadRecords(this.lvTake, true);
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadRecords(ListView gv, Boolean FromDealer)
        {
            DateTime from = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00AM");
            DateTime to = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 11:59PM");

            SalitaEntities db = new SalitaEntities();

            IQueryable<v_CustomerNeeds> R = null;

            R = db.v_CustomerNeeds.Where(p => p.FromDealer == FromDealer && p.WasFullfilled == false && p.RequestDateTime >= from && p.RequestDateTime <= to && p.RequestedService_ID == 3).OrderBy(p => p.RequestDateTime).OrderBy(p => p.WasFullfilled);
            
            gv.DataSource = R.ToList();
            gv.DataBind();
        }

        protected void lbComplete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandArgument;

            Response.Redirect("service_complete.aspx?id=" + id);
        }
    }
}
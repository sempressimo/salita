using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class report_services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.txtFrom.Value = this.txtTo.Value = DateTime.Today.ToShortDateString();

                    this.LoadRecords();
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadRecords()
        {
            DateTime from = Convert.ToDateTime(this.txtFrom.Value + " 12:00AM");
            DateTime to = Convert.ToDateTime(this.txtTo.Value + " 11:59PM");

            bool Todays = (RadioButtonList1.SelectedIndex == 0) ? true : false;

            SalitaEntities db = new SalitaEntities();

            //var R = db.v_CustomerNeeds.Where(p => p.RequestDateTime >= from && p.RequestDateTime <= to).OrderBy(p => p.RequestDateTime);

            var R = from p in db.v_CustomerNeeds
                        group p by p.ServiceDescription into g
                        select new
                        {
                            name = g.Key,
                            count = g.Count()
                        };

            this.gvRecords.DataSource = R.ToList();
            this.gvRecords.DataBind();

            if (R != null)
            {
                this.gvRecords.Caption = "Tipos de servicio: " + R.Count();
            }
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadRecords();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                this.txtFrom.Value = this.txtTo.Value = DateTime.Today.ToShortDateString();

                this.txtFrom.Disabled = this.txtTo.Disabled = true;

                this.LoadRecords();
            }
            else
            {
                this.txtFrom.Disabled = this.txtTo.Disabled = false;
            }
        }

        protected void gvRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row_index = Convert.ToInt32(e.CommandArgument);

                string id = this.gvRecords.DataKeys[row_index].Value.ToString();

                Response.Redirect("service_complete.aspx?id=" + id);
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
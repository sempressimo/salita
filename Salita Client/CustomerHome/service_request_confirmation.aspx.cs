using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client.CustomerHome
{
    public partial class service_request_confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ViewState["cid"] = Request.QueryString["cid"];
                ViewState["sid"] = Request.QueryString["sid"];
                ViewState["note"] = Request.QueryString["n"];

                this.txtNote.Value = ViewState["note"].ToString();

                SalitaEntities db = new SalitaEntities();

                int sid = Convert.ToInt32(ViewState["sid"]);

                var S = db.CustomerServices.Single(p => p.CustomerService_ID == sid);
                this.lblRefreshment.Text = S.ServiceDescription;

            }
            catch (Exception E)
            {
                this.CustomValidator1.ErrorMessage = E.Message;
                this.CustomValidator1.IsValid = false;
            }
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("request_service.aspx"); 
        }

        protected void lbConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                int cid = Convert.ToInt32(ViewState["cid"]);
                int sid = Convert.ToInt32(ViewState["sid"]);

                SalitaEntities db = new SalitaEntities();

                CustomerNeed N = new CustomerNeed();

                N.Canceled = false;
                N.Customer_ID = cid;
                N.Note = this.txtNote.Value;
                N.RequestDateTime = DateTime.Now;
                N.RequestedService_ID = sid;
                N.WasFullfilled = false;

                db.CustomerNeeds.Add(N);

                UpdateHub.SendServer("");

                Response.Redirect("request_service_feedback.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.ErrorMessage = E.Message;
                this.CustomValidator1.IsValid = false;
            }
        }
    }
}
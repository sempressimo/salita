using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class request_note : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    SalitaEntities db = new SalitaEntities();

                    if (Request.QueryString["id"] == null || Request.QueryString["sid"] == null)
                    {
                        this.cmdOK.Enabled = false;

                        throw new Exception("id or sid was not supplied.");
                    }
                    else
                    {
                        ViewState["Customer_ID"] = Request.QueryString["id"];
                        ViewState["sid"] = Request.QueryString["sid"];

                        int cid = Convert.ToInt32(ViewState["Customer_ID"]);
                        int sid = Convert.ToInt32(ViewState["sid"]);

                        Customer C = db.Customers.Single(p => p.Customer_ID == cid);

                        this.lblFullName.Text = C.FullName;

                        CustomerService S = db.CustomerServices.Single(p => p.CustomerService_ID == sid);

                        this.lblServiceRequested.Text = S.ServiceDescription;

                        if (sid == 1)
                        {
                            this.imageIcon.ImageUrl = @"images\pop_water.png";
                        }
                        else if (sid == 2)
                        {
                            this.imageIcon.ImageUrl = @"images\pop_soda.png";
                        }
                        else if (sid == 3)
                        {
                            this.imageIcon.ImageUrl = @"images\pop_cafe.png";
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;

                if (E.InnerException != null)
                {
                    this.CustomValidator1.ErrorMessage += " InnerException: " + E.InnerException.Message;
                }
            }
        }

        protected void SetService(int Customer_ID, int Service_ID)
        {
            SalitaEntities db = new SalitaEntities();

            var Need = new CustomerNeed();

            Need.RequestDateTime = DateTime.Now;
            Need.Customer_ID = Customer_ID;
            Need.WasFullfilled = false;
            Need.Note = this.txtServiceNote.Text;
            Need.RequestedService_ID = Service_ID;

            db.CustomerNeeds.Add(Need);
            db.SaveChanges();
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                int cid = Convert.ToInt32(ViewState["Customer_ID"]);
                int sid = Convert.ToInt32(ViewState["sid"]);

                this.SetService(cid, sid);

                UpdateHub.SendServer("");

                Response.Redirect("default.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;

                if (E.InnerException != null)
                {
                    this.CustomValidator1.ErrorMessage += " InnerException: " + E.InnerException.Message;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class change_mood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    SalitaEntities db = new SalitaEntities();

                    if (Request.QueryString["id"] == null || Request.QueryString["vid"] == null)
                    {
                        this.cmdOK.Enabled = false;

                        throw new Exception("id or visit_id was not supplied.");
                    }
                    else
                    {
                        ViewState["Customer_ID"] = Request.QueryString["id"];
                        ViewState["m"] = Request.QueryString["m"];
                        ViewState["vid"] = Request.QueryString["vid"];

                        int cid = Convert.ToInt32(ViewState["Customer_ID"]);
                        string m = ViewState["m"].ToString();

                        Customer C = db.Customers.Single(p => p.Customer_ID == cid);

                        this.lblFullName.Text = C.FullName;

                        //CustomerService S = db.CustomerServices.Single(p => p.CustomerService_ID == sid);

                        //this.lblServiceRequested.Text = S.ServiceDescription;

                        if (m == "N")
                        {
                            this.imageIcon.ImageUrl = @"images\customer_neutral.png";
                        }
                        else if (m == "G")
                        {
                            this.imageIcon.ImageUrl = @"images\face_idle.png";
                        }
                        else if (m == "B")
                        {
                            this.imageIcon.ImageUrl = @"images\face_bad.png";
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

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                int vid = Convert.ToInt32(ViewState["vid"]);

                SalitaEntities db = new SalitaEntities();

                var V = db.Visits.Single(p => p.Visit_ID == vid);

                V.Mood = ViewState["m"].ToString();

                db.SaveChanges();

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
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class service_complete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["id"] == null)
                    {
                        this.cmdOK.Enabled = false;
 
                        throw new Exception("id was not supplied.");
                    }
                    else
                    {
                        ViewState["id"] = Request.QueryString["id"];

                        int ID = Convert.ToInt32(ViewState["id"]);

                        SalitaEntities db = new SalitaEntities();

                        var Need = db.v_CustomerNeeds.Single(p => p.CustomerNeed_ID == ID);

                        this.lblFullName.Text = Need.FullName;
                        this.txtServiceDesc.Text = Need.ServiceDescription + ": " + Need.Address_Line + " " + Need.Town;

                        ViewState["ServiceType"] = Need.ServiceType;
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

        protected void FullfillService(int ID)
        {
            SalitaEntities db = new SalitaEntities();

            var Need = db.CustomerNeeds.Single(p => p.CustomerNeed_ID == ID);

            Need.WasFullfilled = true;

            db.SaveChanges();
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ViewState["id"]);

                this.FullfillService(id);

                UpdateHub.SendServer("");

                if (ViewState["ServiceType"].ToString() == "T")
                {
                    Response.Redirect("report_transportation.aspx");
                }
                else
                {
                    Response.Redirect("default.aspx");
                }
            }
            catch(Exception E)
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
            if (ViewState["ServiceType"].ToString() == "T")
            {
                Response.Redirect("report_transportation.aspx");
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }
}
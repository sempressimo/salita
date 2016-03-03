using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class transport_page_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["sid"] != null)
                    {
                        ViewState["Service_ID"] = Request.QueryString["sid"];

                        this.LoadNeed(Convert.ToInt32(ViewState["Service_ID"]));
                    }
                    else
                    {
                        ViewState["id"] = Request.QueryString["id"];
                    }

                    this.LoadLists();
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadNeed(int id)
        {
            SalitaEntities db = new SalitaEntities();

            var N = db.v_CustomerNeeds.Single(p => p.CustomerNeed_ID == id);

            this.lblFullName.InnerText = "Editar transportación para el cliente: " + N.FullName;
            this.txtAddressLine1.Value = N.Address_Line;
            this.txtZipCode.Text = N.ZipCode;
            this.txtTown.Value = N.Town;

            string Time = N.RequestDateTime.Value.ToShortTimeString();

            if (this.cmbTime.Items.FindByText(Time) != null)
            {
                this.cmbTime.Items.FindByText(Time).Selected = true;
            }
        }

        protected void LoadLists()
        {
            SalitaEntities db = new SalitaEntities();

            var L = db.HourSlots.Where(p => p.IsActive == true).OrderBy(p => p.HourSlotOrder);

            this.cmbTime.DataSource = L.ToList();
            this.cmbTime.DataTextField = "HourSlotTime";
            this.cmbTime.DataValueField = "HourSlotTime";
            this.cmbTime.DataBind();
        }

        protected void lbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                SalitaEntities db = new SalitaEntities();

                int id = Convert.ToInt32(ViewState["Service_ID"]);

                var N = db.CustomerNeeds.Single(p => p.CustomerNeed_ID == id);

                N.Address_Line = this.txtAddressLine1.Value;
                N.Town = this.txtTown.Value;
                N.ZipCode = this.txtZipCode.Text;
                N.RequestDateTime = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + this.cmbTime.SelectedValue);
                // TODO: add a field for # of companions
                
                db.SaveChanges();

                //
                // Edit the AG Form
                //
                if (N.RequestedService_ID == 3)
                {
                    // Only update the drive to record
                    DateTime NeedDateLow = Convert.ToDateTime(N.RequestDateTime.Value.ToShortDateString() + " 12:00AM");
                    DateTime NeedDateHigh = Convert.ToDateTime(N.RequestDateTime.Value.ToShortDateString() + " 11:59PM");

                    var V = db.Visits.Single(p => p.Customer_ID == N.Customer_ID && p.VisitDate >= NeedDateLow && p.VisitDate <= NeedDateHigh);

                    V.AG_DriveTo = this.txtAddressLine1.Value;
                    V.AG_Companions = Convert.ToInt32(this.cmbCompanions.SelectedValue);
                    V.AG_ExitTime = this.cmbTime.Text;

                    db.SaveChanges();
                }

                Response.Redirect("transport_page.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("transport_page.aspx");
        }

        protected void txtZipCode_TextChanged(object sender, EventArgs e)
        {
            if (this.txtZipCode.Text != "")
            {
                SalitaEntities db = new SalitaEntities();

                ListZip z = db.ListZips.SingleOrDefault(p => p.ZipCode == this.txtZipCode.Text);

                if (z != null)
                {
                    this.txtTown.Value = z.City;
                }
            }
        }
    }
}
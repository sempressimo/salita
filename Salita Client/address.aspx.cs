using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class address : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                ViewState["id"] = Request.QueryString["id"];
                this.lblFullName.Text = Request.QueryString["name"];

                this.LoadLists();
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

        protected void txtZipCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtZipCode.Text != "")
                {
                    SalitaEntities db = new SalitaEntities();

                    ListZip z = db.ListZips.SingleOrDefault(p => p.ZipCode == this.txtZipCode.Text);

                    if (z != null)
                    {
                        this.txtTown.Text = z.City;
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                int Service_ID = 3;

                int Customer_ID = Convert.ToInt32(ViewState["id"]);

                SalitaEntities db = new SalitaEntities();

                DateTime from = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00AM");
                DateTime to = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 11:59PM");

                if (db.CustomerNeeds.SingleOrDefault(p => p.Customer_ID == Customer_ID && p.RequestDateTime >= from && p.RequestDateTime <= to && p.RequestedService_ID == Service_ID && p.WasFullfilled == false) == null)
                {
                    CustomerNeed S = new CustomerNeed();

                    S.Customer_ID = Customer_ID;
                    S.RequestDateTime = DateTime.Now;
                    S.WasFullfilled = false;
                    S.RequestedService_ID = Service_ID; // 3 == fuera del dealer
                    S.Address_Line = this.txtSendTo.Text;
                    S.Town = this.txtTown.Text;
                    S.ZipCode = this.txtZipCode.Text;
                    S.FromDealer = (this.cmbWhereTo.SelectedIndex == 0) ? true : false;
                    S.Canceled = false;

                    db.CustomerNeeds.Add(S);
                    db.SaveChanges();

                    if (this.cbRoundTrip.Checked)
                    {
                        S.WasFullfilled = false;
                        S.RequestedService_ID = 4; // 4 == transportacion al dealer
                        S.RequestDateTime = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " " + this.cmbTime.SelectedValue);
                        S.FromDealer = !S.FromDealer;
                        db.CustomerNeeds.Add(S);
                        db.SaveChanges();
                    }

                    Response.Redirect("report_transportation.aspx");
                }
                else
                {
                    throw new Exception("Ya existe un pedido de transportación para hoy el cliente con id: " + Customer_ID.ToString());
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message; 
            }
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void cbUseRegisteredAddress_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbUseRegisteredAddress.Checked)
                {
                    SalitaEntities db = new SalitaEntities();

                    int Customer_ID = Convert.ToInt32(ViewState["id"]);

                    var C = db.Customers.Single(p => p.Customer_ID == Customer_ID);

                    this.txtSendTo.Text = C.Address;
                    this.txtZipCode.Text = C.ZipCode;
                    this.txtTown.Text = C.Town;
                }
                else
                {
                    this.txtSendTo.Text = "";
                    this.txtZipCode.Text = "";
                    this.txtTown.Text = "";
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void cbRoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            divPickupTime.Visible = this.cbRoundTrip.Checked;
        }

        protected void cmbWhereTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbWhereTo.SelectedIndex == 0)
            {
                this.div_RoundTrip.Visible = true;
            }
            else
            {
                this.div_RoundTrip.Visible = false;
            }
        }
    }
}
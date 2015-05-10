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
            }
        }

        protected void txtZipCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SalitaEntities db = new SalitaEntities();

                ListZip z = db.ListZips.SingleOrDefault(p => p.ZipCode == this.txtZipCode.Text);

                if (z != null)
                {
                    this.txtTown.Text = z.City;
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

                if (db.CustomerNeeds.SingleOrDefault(p => p.Customer_ID == Customer_ID && p.RequestedService_ID == Service_ID && p.WasFullfilled == false) == null)
                {
                    CustomerNeed S = new CustomerNeed();

                    S.Customer_ID = Customer_ID;
                    S.RequestDateTime = DateTime.Now;
                    S.WasFullfilled = false;
                    S.RequestedService_ID = Service_ID; // 3 == fuera del dealer
                    S.Address_Line = this.txtSendTo.Text;
                    S.Town = this.txtTown.Text;
                    S.ZipCode = this.txtZipCode.Text;
                    S.FromDealer = (this.rblWhereTo.SelectedIndex == 0) ? true : false;

                    db.CustomerNeeds.Add(S);
                    db.SaveChanges();

                    Response.Redirect("default.aspx");
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
    }
}
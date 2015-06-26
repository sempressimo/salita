using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client.CustomerHome
{
    public partial class user_transport_cancel : System.Web.UI.Page
    {
        SalitaEntities db = new SalitaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ViewState["id"] = Request.QueryString["id"];

                this.LoadRecord(Convert.ToInt32(ViewState["id"]));
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadRecord(int id)
        {
            var R = db.v_CustomerNeeds.Single(p => p.CustomerNeed_ID == id);

            this.lblAddress.Text = R.Address_Line;
            this.lblCountry.Text = "PR";
            this.lblCustomerName.Text = R.FullName;
            this.lblPhone.Text = Regex.Replace(R.Phone, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            this.lblTown.Text = R.Town;
            this.lblZipCode.Text = R.ZipCode;
        }

        protected void lbComplete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ViewState["id"]);

                var R = db.CustomerNeeds.Single(p => p.CustomerNeed_ID == id);

                this.db.CustomerNeeds.Remove(R);
                this.db.SaveChanges();

                Response.Redirect("my_transports.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("my_transports.aspx");
        }
    }
}
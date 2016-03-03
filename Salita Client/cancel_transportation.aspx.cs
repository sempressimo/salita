using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class cancel_transportation : System.Web.UI.Page
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

                int? RequestedService_ID = R.RequestedService_ID;

                this.db.CustomerNeeds.Remove(R);
                this.db.SaveChanges();

                //
                // Update the AG Form
                //
                if (RequestedService_ID == 3)
                {
                    // Only update the drive to record
                    DateTime NeedDateLow = Convert.ToDateTime(R.RequestDateTime.Value.ToShortDateString() + " 12:00AM");
                    DateTime NeedDateHigh = Convert.ToDateTime(R.RequestDateTime.Value.ToShortDateString() + " 11:59PM");

                    var V = db.Visits.Single(p => p.Customer_ID == R.Customer_ID && p.VisitDate >= NeedDateLow && p.VisitDate <= NeedDateHigh);

                    V.AG_DriveTo = "";
                    V.AG_Companions = 0;
                    V.AG_ExitTime = "";
                    V.AG_LL = false;

                    db.SaveChanges();
                }
                else if (RequestedService_ID == 4)
                {
                    // Only update the drive from record
                    DateTime NeedDateLow = Convert.ToDateTime(R.RequestDateTime.Value.ToShortDateString() + " 12:00AM");
                    DateTime NeedDateHigh = Convert.ToDateTime(R.RequestDateTime.Value.ToShortDateString() + " 11:59PM");

                    var V = db.Visits.Single(p => p.Customer_ID == R.Customer_ID && p.VisitDate >= NeedDateLow && p.VisitDate <= NeedDateHigh);

                    V.AG_RR = false;

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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class customer_arrived : System.Web.UI.Page
    {
        SalitaEntities db = new SalitaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["id"] == null)
                    {
                        throw new Exception("Customer id was not provided.");
                    }
                    else
                    {
                        int Customer_ID = Convert.ToInt32(Request.QueryString["id"]);

                        ViewState["Customer_ID"] = Customer_ID;

                        this.LoadCustomers(Customer_ID);
                        this.LoadCustomerServices(Customer_ID);

                        this.LoadWaitingForData();

                        if (CustomerIsInLounge(Customer_ID))
                        {
                            this.cmdSeatInRoom.Enabled = false;

                            throw new Exception("El cliente ya esta en sala virtual.");
                        }
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadWaitingForData()
        {
            var W = this.db.WatingForReasons.OrderBy(p => p.ReasonDescription);

            this.rblWaitingFor.DataTextField = "ReasonDescription";
            this.rblWaitingFor.DataValueField = "WatingForReason_ID";

            this.rblWaitingFor.DataSource = W.ToList();
            this.rblWaitingFor.DataBind();

            if (this.rblWaitingFor.Items.Count > 0)
            {
                this.rblWaitingFor.Items[0].Selected = true;  
            }
        }

        protected void LoadCustomers(int Customer_ID)
        {
            var C = this.db.Customers.Single(p => p.Customer_ID == Customer_ID);


            this.lblFullName.Text = C.FullName + " (" + C.Town + ")";
        }

        protected void LoadCustomerServices(int Customer_ID)
        {
            var S = this.db.v_CustomerNeeds.Where(p => p.Customer_ID == Customer_ID);

            this.gvCustomerServices.DataSource = null;
            this.gvCustomerServices.DataBind();
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("customers_list.aspx");
        }

        protected bool CustomerIsInLounge(int Customer_ID)
        {
            var V = this.db.Visits.SingleOrDefault(p => p.Customer_ID == Customer_ID && p.InLounge == true);

            if (V != null)
            {
                return true;
            }

            return false;
        }

        protected void cmdSeatInRoom_Click(object sender, EventArgs e)
        {
            try
            {
                Visit V = new Visit();

                V.Customer_ID = Convert.ToInt32(ViewState["Customer_ID"]);
                V.Seat_X = 0;
                V.Seat_Y = 0;
                V.InLounge = true;
                V.VisitDate = DateTime.Today;
                V.VisitTime = DateTime.Now.TimeOfDay;
                V.WaitingFor = rblWaitingFor.SelectedItem.Text;  

                this.db.Visits.Add(V);
                this.db.SaveChanges();

                this.cmdSeatInRoom.Enabled = false;

                throw new Exception("El cliente fue sentado en la sala virtual.");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
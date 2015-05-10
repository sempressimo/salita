using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class customers_list : System.Web.UI.Page
    {
        SalitaEntities db = new SalitaEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["name"] != null) this.txtSearch.Text = Request.QueryString["name"];

                    this.LoadCustomers();
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadCustomers()
        {
            var C = this.db.Customers.Where(p => (p.FullName.Contains(this.txtSearch.Text) || String.IsNullOrEmpty(this.txtSearch.Text )) && p.IsActive == true).OrderBy(p => p.FullName);

            this.gvCustomers.DataSource = C.ToList();
            this.gvCustomers.DataBind();
        }

        protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row_id = Convert.ToInt32(e.CommandArgument);

                string Key = this.gvCustomers.DataKeys[row_id].Value.ToString();

                if (e.CommandName == "Arrived")
                {
                    Response.Redirect("customer_arrived.aspx?id=" + Key);
                }
                else if (e.CommandName == "Edit")
                {
                    Response.Redirect("customer_detail.aspx?id=" + Key);
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadCustomers();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void gvCustomers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(this.gvCustomers.DataKeys[e.RowIndex].Value);

                var C = this.db.Customers.Single(p => p.Customer_ID == ID);

                this.db.Customers.Remove(C);
                this.db.SaveChanges();

                this.LoadCustomers();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void lbAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("customer_detail.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
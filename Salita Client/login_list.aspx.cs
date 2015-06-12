using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class login_list : System.Web.UI.Page
    {
        SalitaEntities db = new SalitaEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["name"] != null) this.txtSearch.Text = Request.QueryString["name"];

                    this.LoadRecords();
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadRecords()
        {
            var C = this.db.Users.Where(p => p.Username.Contains(this.txtSearch.Text)).OrderBy(p => p.Username);

            this.gvRecords.DataSource = C.ToList();
            this.gvRecords.DataBind();
        }

        protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row_id = Convert.ToInt32(e.CommandArgument);

                string Key = this.gvRecords.DataKeys[row_id].Value.ToString();

                if (e.CommandName == "Update")
                {
                    Response.Redirect("login_detail.aspx?id=" + Key);
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
                this.LoadRecords();
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
                string ID = this.gvRecords.DataKeys[e.RowIndex].Value.ToString();

                var C = this.db.Users.Single(p => p.Username == ID);

                this.db.Users.Remove(C);
                this.db.SaveChanges();

                this.LoadRecords();
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
                Response.Redirect("login_detail.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
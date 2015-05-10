using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class customer_detail : System.Web.UI.Page
    {
        SalitaEntities db = new SalitaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string id = Request.QueryString["id"];

                    ViewState["id"] = id;

                    if (id != null)
                    {
                        this.LoadCustomer(Convert.ToInt32(id));
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadCustomer(int Customer_ID)
        {
            var C = this.db.Customers.Single(p => p.Customer_ID == Customer_ID);

            this.txtFullName.Text = C.FullName;
            this.txtAddress.Text = C.Address;
            this.txtPhone.Text = C.Phone;
            this.txtZipCode.Text = C.ZipCode;
            this.txtEmail.Text = C.Email;
            this.cbIsActive.Checked = C.IsActive.Value;
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("customers_list.aspx");
        }

        protected void Add()
        {
            Customer C = new Customer();

            C.FullName = this.txtFullName.Text;
            C.Address = this.txtAddress.Text;
            C.Email = this.txtEmail.Text;
            C.Phone = this.txtPhone.Text;
            C.Town = this.txtTown.Text;
            C.ZipCode = this.txtZipCode.Text;
            C.IsActive = this.cbIsActive.Checked;

            this.db.Customers.Add(C);
            this.db.SaveChanges();
        }

        protected void Update()
        {
            int Customer_ID = Convert.ToInt32(ViewState["id"]);

            Customer C = this.db.Customers.Single(p => p.Customer_ID == Customer_ID);

            C.FullName = this.txtFullName.Text;
            C.Address = this.txtAddress.Text;
            C.Email = this.txtEmail.Text;
            C.Phone = this.txtPhone.Text;
            C.Town = this.txtTown.Text;
            C.ZipCode = this.txtZipCode.Text;
            C.IsActive = this.cbIsActive.Checked;

            this.db.SaveChanges();
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["id"] != null)
                {
                    this.Update();
                }
                else
                {
                    this.Add();
                }

                Response.Redirect("customers_list.aspx?name=" + this.txtFullName.Text);
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void txtZipCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtZipCode.Text != "")
                {
                    var T = this.db.ListZips.SingleOrDefault(p => p.ZipCode == this.txtZipCode.Text);

                    if (T != null)
                    {
                        this.txtTown.Text = T.City;
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
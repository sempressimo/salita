using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class login_detail : System.Web.UI.Page
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
                        this.LoadRecord(id);
                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadRecord(string Username)
        {
            var C = this.db.Users.Single(p => p.Username == Username);

            this.txtUsername.Text = C.Username;
            this.cmbRole.Items.FindByValue(C.Role).Selected = true;
            this.txtPassword.Text = this.txtValidatePassword.Text = C.UserPassword;
        }

        protected void cmdCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("login_list.aspx");
        }

        protected void Add()
        {
            User C = new User();

            C.Username = this.txtUsername.Text;
            C.Role = this.cmbRole.SelectedValue;

            this.db.Users.Add(C);
            this.db.SaveChanges();
        }

        protected void Update()
        {
            string ID = ViewState["id"].ToString();

            User C = this.db.Users.Single(p => p.Username == ID);

            C.Username = this.txtUsername.Text;
            C.Role = this.cmbRole.SelectedValue;
            C.UserPassword = this.txtPassword.Text;

            this.db.SaveChanges();
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPassword.Text.Length < 6)
                {
                    throw new Exception("Password must be at least 6 characters.");
                }

                if (this.txtPassword.Text != this.txtValidatePassword.Text)
                {
                    throw new Exception("Los passwords no son iguales.");
                }

                if (ViewState["id"] != null)
                {
                    this.Update();
                }
                else
                {
                    this.Add();
                }

                Response.Redirect("login_list.aspx");
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
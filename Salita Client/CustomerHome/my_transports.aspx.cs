﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client.CustomerHome
{
    public partial class my_transports : System.Web.UI.Page
    {
        SalitaEntities db = new SalitaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadTransportations();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadTransportations()
        {
            int cid = Convert.ToInt32(Session["Customer_ID"]);

            DateTime from = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00AM");

            var R = db.CustomerNeeds.Where(p => p.Customer_ID == cid && p.WasFullfilled == false && p.RequestDateTime >= from);

            this.lvTransport.DataSource = R.ToList();
            this.lvTransport.DataBind();
        }

        protected void lbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                string id = btn.CommandArgument;

                Response.Redirect("user_transport_cancel.aspx?id=" + id);
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
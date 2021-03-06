﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class report_transportation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.txtFrom.Value = this.txtTo.Value = DateTime.Today.ToShortDateString();

                    LoadBothGrids();
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message; 
            }
        }

        protected void LoadBothGrids()
        {
            this.LoadRecords(this.gvRecords, true);
            this.LoadRecords(this.gvToDealder, false);
        }

        protected void LoadRecords(GridView gv, Boolean FromDealer)
        {
            DateTime from = Convert.ToDateTime(this.txtFrom.Value + " 12:00AM");
            DateTime to = Convert.ToDateTime(this.txtTo.Value + " 11:59PM");

            bool Todays = (this.ddlReportType.SelectedIndex == 0) ? true : false;

            SalitaEntities db = new SalitaEntities();

            IQueryable<v_CustomerNeeds> R = null;

            if (Todays)
            {
                R = db.v_CustomerNeeds.Where(p => p.FromDealer == FromDealer && p.WasFullfilled == false && p.RequestDateTime >= from && p.RequestDateTime <= to && (p.RequestedService_ID == 3 || p.RequestedService_ID == 4)).OrderBy(p => p.RequestDateTime).OrderBy(p => p.WasFullfilled);
            }
            else
            {
                R = db.v_CustomerNeeds.Where(p => p.FromDealer == FromDealer && p.RequestDateTime >= from && p.RequestDateTime <= to && (p.RequestedService_ID == 3 || p.RequestedService_ID == 4)).OrderBy(p => p.RequestDateTime).OrderBy(p => p.WasFullfilled);
            }
 
            gv.DataSource = R.ToList();
            gv.DataBind();

            if (R != null)
            {
                if (FromDealer)
                {
                    gv.Caption = "Llevar del dealer a destino: " + R.Count();
                }
                else
                {
                    gv.Caption = "Recojer en dirección y llevar al dealer: " + R.Count();
                }
            }
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBothGrids();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void gvRecords_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row_index = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "Maps")
                {
                    string Address = this.gvRecords.DataKeys[row_index].Values[1].ToString();
                    string Town = this.gvRecords.DataKeys[row_index].Values[2].ToString();
                    string ZipCode = this.gvRecords.DataKeys[row_index].Values[3].ToString();

                    Response.Redirect("https://www.google.com/maps/place/" + Address + ",+" + Town + ",+" + ZipCode + ",+Puerto+Rico/");
                }
                else if (e.CommandName == "Close")
                {
                    string id = this.gvRecords.DataKeys[row_index].Value.ToString(); 

                    Response.Redirect("service_complete.aspx?id=" + id);
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void gvRecords_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int PhoneIndex = 2;

                    var c = e.Row.Cells[PhoneIndex];

                    if (c.Text.Length == 10)
                    {
                        //c.Text = String.Format("{0:(###) ###-####}", c.Text);

                        c.Text = Regex.Replace(c.Text, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

                    }
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlReportType.SelectedIndex == 0)
            {
                this.txtFrom.Value = this.txtTo.Value = DateTime.Today.ToShortDateString();

                this.txtFrom.Disabled = this.txtTo.Disabled = true;

                LoadBothGrids();
            }
            else
            {
                this.txtFrom.Disabled = this.txtTo.Disabled = false;
            }
        }
    }
}
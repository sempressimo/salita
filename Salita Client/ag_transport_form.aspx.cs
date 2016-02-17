﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class ag_transport_form : System.Web.UI.Page
    {
        SalitaEntities db = new SalitaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    this.LoadVisits();
                }
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }

        protected void LoadVisits()
        {
            var TodaysVisits = this.db.v_AG_Transport.OrderBy(x => x.VisitDate);

            this.ListView1.DataSource = TodaysVisits.ToList();
            this.ListView1.DataBind();
        }

        protected string ParseDate(object f)
        {
            if (f == null)
            { 
                return "[pendiente]";
            }
            else if (f.ToString().Trim() == "")
            {
                return "[pendiente]";
            }
            else if (f.ToString() == "1/1/1900")
            {
                return "[pendiente]";
            }

            return Convert.ToDateTime(f).ToShortTimeString();
        }

        protected string GetDefaultString(object f)
        {
            if (f == null)
            {
                return "(edit)";
            }
            else if (f.ToString() == "")
            {
                // Needed?
                return "(edit)";
            }

            return f.ToString();
        }

        protected Boolean GetDefaultBool(object f)
        {
            if (f == null)
            {
                return false;
            }

            return Convert.ToBoolean(f);
        }

        protected int GetSeatNumber(int Seat_X, int Seat_Y)
        {
            if (Seat_X == 0 && Seat_Y == 0)
            {
                return 0;
            }


            return 0;
        }

        protected void GetSeatCoords(int SeatNum, ref int? SeatX, ref int? SeatY)
        {
            switch (SeatNum)
            { 
                case 1:
                    SeatX = 1;
                    SeatY = 11;
                    break;
                case 2:
                    SeatX = 2;
                    SeatY = 11;
                    break;
                case 3:
                    SeatX = 3;
                    SeatY = 11;
                    break;
                case 4:
                    SeatX = 4;
                    SeatY = 10;
                    break;
                case 5:
                    SeatX = 4;
                    SeatY = 9;
                    break;
                case 6:
                    SeatX = 3;
                    SeatY = 8;
                    break;
                case 7:
                    SeatX = 2;
                    SeatY = 8;
                    break;
                case 8:
                    SeatX = 1;
                    SeatY = 8;
                    break;
                case 9:
                    SeatX = 1;
                    SeatY = 7;
                    break;
                case 10:
                    SeatX = 2;
                    SeatY = 7;
                    break;
                case 11:
                    SeatX = 3;
                    SeatY = 7;
                    break;
                case 12:
                    SeatX = 4;
                    SeatY = 6;
                    break;
                case 13:
                    SeatX = 4;
                    SeatY = 5;
                    break;
                case 14:
                    SeatX = 1;
                    SeatY = 0;
                    break;
                case 15:
                    SeatX = 3;
                    SeatY = 0;
                    break;
                case 16:
                    SeatX = 4;
                    SeatY = 1;
                    break;
                case 17:
                    SeatX = 4;
                    SeatY = 2;
                    break;
                case 18:
                    SeatX = 5;
                    SeatY = 3;
                    break;
                case 19:
                    SeatX = 6;
                    SeatY = 3;
                    break;
                case 20:
                    SeatX = 8;
                    SeatY = 2;
                    break;
                case 21:
                    SeatX = 8;
                    SeatY = 1;
                    break;
                case 22:
                    SeatX = 9;
                    SeatY = 4;
                    break;
                case 23:
                    SeatX = 8;
                    SeatY = 4;
                    break;
                case 24:
                    SeatX = 7;
                    SeatY = 5;
                    break;
                case 25:
                    SeatX = 7;
                    SeatY = 6;
                    break;
                case 26:
                    SeatX = 7;
                    SeatY = 7;
                    break;
                case 27:
                    SeatX = 7;
                    SeatY = 8;
                    break;
                case 28:
                    SeatX = 9;
                    SeatY = 1;
                    break;
                case 29:
                    SeatX = 9;
                    SeatY = 9;
                    break;
                case 30:
                    SeatX = 11;
                    SeatY = 9;
                    break;
                case 31:
                    SeatX = 11;
                    SeatY = 11;
                    break;
            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                int RecId = 0;
                int.TryParse(Request.Form["myRecordId"].ToString(), out RecId);

                // Not been saved
                var FullName = this.txtEditFullName.Value;
                var Phone = this.txtEditPhone.Value;

                var VisitRecord = db.Visits.Single(p => p.Visit_ID == RecId);

                VisitRecord.AG_Phone = Phone;

                if (string.IsNullOrEmpty(this.cmbCompanions.Value))
                {
                    VisitRecord.AG_Companions = 0;
                }
                else
                {
                    VisitRecord.AG_Companions = Convert.ToInt32(this.cmbCompanions.Value);
                }

                VisitRecord.AG_LL = Convert.ToBoolean(this.cbLL.Checked);
                VisitRecord.AG_RR = Convert.ToBoolean(this.lbR.Checked);
                
                VisitRecord.AG_Tag = this.txtTag.Value;  
                VisitRecord.AG_Advisor = this.txtAdvisor.Value;
                VisitRecord.AG_DriveTo = this.txtDriveTo.Value;
                
                VisitRecord.AG_AppointmentTime = this.txtAppointment.Value;
                VisitRecord.AG_RegisteredTime = this.txtSignedInTime.Value;
                VisitRecord.AG_AttendedTime = this.txtAtended.Value;
                VisitRecord.AG_ArrivalTime = this.txtArriveTime.Value;
                VisitRecord.AG_ExitTime = this.txtLeaveTime.Value;
                
                VisitRecord.AG_OK = this.cbOK.Checked;
                VisitRecord.AG_DriverName = this.txtDriver.Value;

                int? Seat_X = 0;
                int? Seat_Y = 0;
                this.GetSeatCoords(1, ref Seat_X, ref Seat_Y);

                VisitRecord.Seat_X = Seat_X;
                VisitRecord.Seat_Y = Seat_Y;

                this.db.SaveChanges();

                this.LoadVisits();
            }
            catch (DbEntityValidationException dbex)
            {
                string validationErrors = "";

                foreach (var eve in dbex.EntityValidationErrors)
                {
                    validationErrors = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        validationErrors += string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = validationErrors;
            }
            catch (Exception ex)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = ex.Message;
            }
        }

        protected void cmdNewVisit_Click(object sender, EventArgs e)
        {
            try
            {
                string inputFullName = this.txtNewVisitName.Value;
                string inputPhone = Regex.Replace(this.txtNewVisitPhone.Value, @"[^0-9]+", "");

                string FormattedPhone = String.Format("{0:(###) ###-####}", Convert.ToDouble(inputPhone));

                var _Customer = this.db.Customers.SingleOrDefault(p => p.Phone == FormattedPhone);

                int Customer_ID = 0;

                if (_Customer == null)
                {
                    //
                    // Customer not found, create the record
                    //
                    Customer c = new Customer();
                    c.Phone = FormattedPhone;
                    c.Address = "";
                    c.Email = "";
                    c.FullName = inputFullName;
                    c.IsActive = true;

                    this.db.Customers.Add(c);
                    this.db.SaveChanges();

                    Customer_ID = c.Customer_ID;
                }
                else
                {
                    Customer_ID = _Customer.Customer_ID;
                }

                //
                // Create the new visit
                //
                Visit v = new Visit();

                v.AG_Advisor = "[None]";
                v.AG_AppointmentTime = "";
                v.AG_ArrivalTime = "";
                v.AG_AttendedTime = "";
                v.AG_Companions = 0;
                v.AG_DriverName = "[None]";
                v.AG_DriveTo = "";
                v.AG_ExitTime = "";
                v.AG_LL = false;
                v.AG_OK = false;
                v.AG_Phone = FormattedPhone;
                v.AG_RegisteredTime = DateTime.Now.ToShortTimeString();
                v.AG_RR = false;
                v.AG_Tag = "";
                v.Customer_ID = Customer_ID;
                v.InLounge = true;
                v.LoginPIN = "1234";
                v.Mood = "";
                v.Seat_X = 0;
                v.Seat_Y = 0;
                v.VisitDate = DateTime.Today;
                v.WaitingFor = "";

                this.db.Visits.Add(v);
                this.db.SaveChanges();

                this.LoadVisits();
            }
            catch (Exception ex)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = ex.Message;
            }
        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int cId = Convert.ToInt32(this.txtCustomer_ID.Value);

                var _V = this.db.Visits.SingleOrDefault(p => p.Visit_ID == cId);

                if (_V != null)
                {
                    this.db.Visits.Remove(_V);
                    this.db.SaveChanges();

                    this.LoadVisits();
                }
            }
            catch (Exception ex)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = ex.Message;
            }
        }
    }
}
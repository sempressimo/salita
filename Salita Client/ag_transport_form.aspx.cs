using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
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
                
                VisitRecord.AG_AppointmentTime = string.IsNullOrEmpty(this.txtAppointment.Value) ? Convert.ToDateTime("1/1/1900") : Convert.ToDateTime(this.txtAppointment.Value);
                VisitRecord.AG_RegisteredTime = string.IsNullOrEmpty(this.txtSignedInTime.Value) ? Convert.ToDateTime("1/1/1900") : Convert.ToDateTime(this.txtSignedInTime.Value);
                VisitRecord.AG_AttendedTime = string.IsNullOrEmpty(this.txtAtended.Value) ? Convert.ToDateTime("1/1/1900") : Convert.ToDateTime(this.txtAtended.Value);
                VisitRecord.AG_ArrivalTime = string.IsNullOrEmpty(this.txtArriveTime.Value) ? Convert.ToDateTime("1/1/1900") : Convert.ToDateTime(this.txtArriveTime.Value);
                VisitRecord.AG_ExitTime = string.IsNullOrEmpty(this.txtLeaveTime.Value) ? Convert.ToDateTime("1/1/1900") : Convert.ToDateTime(this.txtLeaveTime.Value);
                
                VisitRecord.AG_OK = this.cbOK.Checked;
                VisitRecord.AG_DriverName = this.txtDriver.Value;

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

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Customer

                Visit v = new Visit();

                v.AG_Companions = 0;

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
    }
}
using System;
using System.Collections.Generic;
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

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                int RecId = 0;
                int.TryParse(Request.Form["myRecordId"].ToString(), out RecId);

                var FullName = this.txtEditFullName.Value;

                var VisitRecord = db.Visits.Single(p => p.Visit_ID == RecId);

                VisitRecord.AG_Advisor = this.txtEditFullName.Value;

                this.db.SaveChanges();

                this.LoadVisits();
            }
            catch (Exception E)
            {
                this.CustomValidator1.IsValid = false;
                this.CustomValidator1.ErrorMessage = E.Message;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
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
            SalitaEntities db = new SalitaEntities();

            var R = db.v_CustomerNeeds.Where(p => p.WasFullfilled == false && p.RequestedService_ID == 3).OrderBy(p => p.RequestDateTime);

            this.gvRecords.DataSource = R.ToList();
            this.gvRecords.DataBind(); 
        }

        protected void lbSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
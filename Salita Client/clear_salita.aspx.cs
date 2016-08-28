using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class clear_salita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LeaveLounge();
            }
            catch (Exception E)
            {
                Response.Write(E.Message);
            }
        }

        public void LeaveLounge()
        {
            SalitaEntities db = new SalitaEntities();

            //
            // Cancel requests except for transportation
            //
            var Needs = db.CustomerNeeds.Where(p => p.WasFullfilled == false && p.Canceled == false && p.RequestedService_ID != 3 && p.RequestedService_ID != 4);

            foreach (CustomerNeed N in Needs)
            {
                SalitaEntities db2 = new SalitaEntities();

                var NeedToUpdate = db2.CustomerNeeds.Single(p => p.CustomerNeed_ID == N.CustomerNeed_ID);

                NeedToUpdate.Canceled = true;

                db2.SaveChanges();
            }

            //
            // Take customer out
            //
            var V = db.Visits.SingleOrDefault(p => p.InLounge == true);

            if (V != null)
            {
                V.InLounge = false;

                db.SaveChanges();
            }
        }
    }
}
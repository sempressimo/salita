using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class _default : System.Web.UI.Page
    {
        public static int PollDatabase = 0;

        SalitaEntities db = new SalitaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static void SetSelectedCustomer(int Customer_ID)
        {
            HttpContext.Current.Session["Selected_Customer_ID"] = Customer_ID;
        }

        public static IEnumerable<v_CustomerNeeds> GetAllNeeds()
        {
            SalitaEntities db = new SalitaEntities();

            return db.v_CustomerNeeds.Where(p => p.WasFullfilled == false).OrderBy(p => p.RequestDateTime);
        }

        [System.Web.Services.WebMethod]
        public static void ChangeSeat(int Customer_ID, int Seat_X, int Seat_Y)
        {
            SalitaEntities db = new SalitaEntities();

            var V = db.Visits.SingleOrDefault(p => p.Customer_ID == Customer_ID && p.InLounge == true);

            if (V != null)
            {
                V.Seat_X = Seat_X;
                V.Seat_Y = Seat_Y;

                db.SaveChanges();

                PollDatabase = 1;
            }
        }

        [System.Web.Services.WebMethod]
        public static void ProcessService(int Customer_ID, int Service_ID)
        {
            SalitaEntities db = new SalitaEntities();

            if (db.CustomerNeeds.SingleOrDefault(p => p.Customer_ID == Customer_ID && p.RequestedService_ID == Service_ID && p.WasFullfilled == false) == null)
            {
                CustomerNeed S = new CustomerNeed();

                S.Customer_ID = Customer_ID;
                S.RequestDateTime = DateTime.Now;
                S.WasFullfilled = false;
                S.RequestedService_ID = Service_ID;

                db.CustomerNeeds.Add(S);
                db.SaveChanges();
            }
        }

        protected void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                int Customer_ID = Convert.ToInt32(HttpContext.Current.Session["Selected_Customer_ID"]);

                var V = this.db.Visits.SingleOrDefault(p => p.Customer_ID == Customer_ID && p.InLounge == true);

                if (V != null)
                {
                    V.InLounge = false;

                    this.db.SaveChanges();

                    PollDatabase = 1;
                }
                else
                {
                    throw new Exception("ID: " + Customer_ID + " es invalido o el cliente ya fue marcado como removido.");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Salita_Client
{
    public partial class _default : System.Web.UI.Page
    {
        //SalitaEntities db = new SalitaEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static IEnumerable<v_CustomerNeeds> GetAllNeeds()
        {
            SalitaEntities db = new SalitaEntities();

            DateTime from = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 12:00AM");
            DateTime to = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 11:59PM");

            var needs = db.v_CustomerNeeds.Where(p => p.WasFullfilled == false && p.Canceled == false && p.RequestDateTime >= from && p.RequestDateTime <= to).OrderBy(p => p.RequestDateTime);

            JavaScriptSerializer TheSerializer = new JavaScriptSerializer();

            var TheJson = TheSerializer.Serialize(needs.ToList());

            //return TheJson;

            return needs;
        }

        [System.Web.Services.WebMethod]
        public static void FullfillService(int ID, string Note)
        {
            SalitaEntities db = new SalitaEntities();

            var Need = db.CustomerNeeds.Single(p => p.CustomerNeed_ID == ID);

            Need.WasFullfilled = true;

            db.SaveChanges();

            /*
            if (this.txtServiceDesc.Text.Length > 19)
            {
                if (this.txtServiceDesc.Text.Substring(0, 20) == "Transportacion Fuera")
                {
                    // Take customer out of salita
                    int Customer_ID = Convert.ToInt32(ViewState["Customer_ID"]);

                    Visit v = db.Visits.SingleOrDefault(p => p.Customer_ID == Customer_ID && p.InLounge == true);

                    if (v != null)
                    {
                        v.InLounge = false;

                        db.SaveChanges();
                    }
                }
            }
            */
        }

        [System.Web.Services.WebMethod]
        public static void SetService(int Customer_ID, int Service_ID, string Note)
        {
            SalitaEntities db = new SalitaEntities();

            var Need = new CustomerNeed();

            Need.RequestDateTime = DateTime.Now;
            Need.Customer_ID = Customer_ID;
            Need.WasFullfilled = false;
            Need.Note = Note;
            Need.RequestedService_ID = Service_ID;
            Need.Canceled = false;

            db.CustomerNeeds.Add(Need);
            db.SaveChanges();
        }

        [System.Web.Services.WebMethod]
        public static void SetSelectedCustomer(int Customer_ID)
        {
            HttpContext.Current.Session["Selected_Customer_ID"] = Customer_ID;
        }

        [System.Web.Services.WebMethod]
        public static void LeaveLounge(int Customer_ID)
        {
            SalitaEntities db = new SalitaEntities();

            //
            // Cancel requests except for transportation
            //
            var Needs = db.CustomerNeeds.Where(p => p.Customer_ID == Customer_ID && p.WasFullfilled == false && p.Canceled == false && p.RequestedService_ID != 3 && p.RequestedService_ID != 4);

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
            var V = db.Visits.SingleOrDefault(p => p.Customer_ID == Customer_ID && p.InLounge == true);

            if (V != null)
            {
                V.InLounge = false;

                db.SaveChanges();
            }
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
                S.Canceled = false;

                db.CustomerNeeds.Add(S);
                db.SaveChanges();
            }
        }
    }
}
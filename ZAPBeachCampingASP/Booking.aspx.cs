using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZAPBeachCampingLib;

namespace ZAPBeachCampingASP
{
    public partial class Booking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TB_Order_Click(object sender, EventArgs e)
        {
            Customer customer = JsonSerializer.Deserialize<Customer>(Request.Form["HF_Customer"]);
            Manager manager = new Manager();
            manager.CreateReservation(new Reservation(
                customer,
                manager.GetSpot("H1"),
                0.0,
                new DateTime(2021, 6, 15),
                new DateTime(2021, 6, 18),
                new List<CustomerType>(),
                new List<Addition>()
            ));
        }
    }
}
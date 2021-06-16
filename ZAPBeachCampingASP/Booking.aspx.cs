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

        protected void BN_Order_Click(object sender, EventArgs e)
        {
            Customer customer = JsonSerializer.Deserialize<Customer>(Request.Form["HF_Customer"]);
            ReservationPrefences reservationPrefences = JsonSerializer.Deserialize<ReservationPrefences>(Request.Form["HF_Camping"]);
            Manager manager = new Manager();
            manager.Failure += OnFailure;
            if (manager.CreateReservation(customer, reservationPrefences))
            {
                MF_Success.Value = "true";
            }
        }

        private void OnFailure(string message)
        {
            LB_Error.Text = message;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(document).ready(function(){$('#mod_error').modal('show');});</script>", false);
        }
    }
}
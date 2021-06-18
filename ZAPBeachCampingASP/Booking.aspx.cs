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
        private Manager Manager { get => (Manager)Session["Manager"]; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BN_Order_Click(object sender, EventArgs e)
        {
            if (ConvertOrderDataFromJson(out var customer, out var reservationPrefences))
            {
                Manager.Failure += OnFailure;
                if (Manager.CreateReservation(customer, reservationPrefences))
                {
                    MF_Success.Value = "true";
                }
            }
        }

        private void OnFailure(string message)
        {
            LB_Error.Text = message;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(document).ready(function(){$('#mod_error').modal('show');});</script>", false);
        }

        private bool ConvertOrderDataFromJson(out Customer customer, out BookingOptions reservationPrefences)
        {
            try
            {
                customer = JsonSerializer.Deserialize<Customer>(Request.Form["HF_Customer"]);
                reservationPrefences = JsonSerializer.Deserialize<BookingOptions>(Request.Form["HF_Camping"]);
                return true;

            }
            catch (Exception excetion)
            {
                OnFailure("Dålige json pakker: " + excetion.Message);

                customer = null;
                reservationPrefences = null;
                return false;
            }

        }
    }
}
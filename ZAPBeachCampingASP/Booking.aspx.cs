using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZAPBeachCampingLib;
using ZAPBeachCampingLib.Core;

namespace ZAPBeachCampingASP
{
    public partial class Booking : System.Web.UI.Page
    {
        private CampingManager Manager { get => (CampingManager)Session["Manager"]; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HF_Additions.Value = JsonSerializer.Serialize(Manager.GetAllAddtion());
            }
        }

        protected void BN_Order_Click(object sender, EventArgs e)
        {
            if (ConvertOrderDataFromJson(out var customer, out var reservationPrefences))
            {
                try
                {
                    Manager.MissingInformation += OnModalMissingInformation;
                    if (Manager.CreateReservation(customer, reservationPrefences))
                    {
                        MF_Success.Value = "true";
                    }
                }
                catch (Exception exception)
                {
                    ShowModalMsg("Fejl 500", exception.Message);
                }
            }
        }

        private void ShowModalMsg(string title, string body)
        {
            LB_ModalTitle.Text = title;
            LB_ModalBody.Text = body;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$(document).ready(function(){$('#mod_error').modal('show');});</script>", false);
        }

        private void OnModalMissingInformation(string msg)
        {
            ShowModalMsg("Du er ikke helt færdig med at udfylde", msg);
        }

        private bool ConvertOrderDataFromJson(out Customer customer, out BookingOptions reservationPrefences)
        {
            try
            {
                customer = JsonSerializer.Deserialize<Customer>(Request.Form["HF_Customer"]);
                reservationPrefences = JsonSerializer.Deserialize<BookingOptions>(Request.Form["HF_BookingOptions"]);
                return true;

            }
            catch (Exception excetion)
            {
                ShowModalMsg("Client side fejl", "Dålige json pakker: " + excetion.Message);

                customer = null;
                reservationPrefences = null;
                return false;
            }
        }
    }
}
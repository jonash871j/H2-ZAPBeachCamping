using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZAPBeachCampingASP
{
    public partial class TestSide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LB_Test.Text = "HELLO";
        }
    }
}
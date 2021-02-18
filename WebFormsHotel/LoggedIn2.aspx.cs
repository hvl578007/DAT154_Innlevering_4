using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using ClassLibraryHotel;

namespace WebFormsHotel
{
    public partial class LoggedIn2 : System.Web.UI.Page
    {
        HotelContext hcx = new HotelContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            User user = WebLoginHelper.CheckIfInloggedSession(Session, hcx);

            if (user != null)
            {
                WelcomeLabel.Text = "Welcome " + user.Name + "!";
                hcx.Reservations.Load(); //?

                GridView1.DataSource = user.Reservations;
                GridView1.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //går til søkesida
            Response.Redirect("SearchRooms.aspx");
        }
    }
}
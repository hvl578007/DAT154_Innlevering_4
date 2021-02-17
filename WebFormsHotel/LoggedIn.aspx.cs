using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace WebFormsHotel
{
    public partial class LoggedIn : System.Web.UI.Page
    {
        HotelContext hcx = new HotelContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = HttpContext.Current.Session["UsernameSession"].ToString();
            var usr = hcx.Users.Local.Where(u => u.Username.Equals(username)); //todo må hente!
            //u = hcx.Users.Local.Find(u => u.UserName.Equals(userName));
            //må vise alle reservasjonar på brukaren
            if (usr != null && usr is User)
            {
                hcx.Reservations.Load(); //?

                GridViewReservations.DataSource = (usr as User).Reservation;
                GridViewReservations.DataBind();
            } else
            {
                //???
            }
            
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            //går til søkesida
            Response.Redirect("SearchRooms.aspx");
        }
    }
}
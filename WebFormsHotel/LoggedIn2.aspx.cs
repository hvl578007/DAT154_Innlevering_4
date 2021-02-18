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
            hcx.Users.Load();
            string username = HttpContext.Current.Session["UsernameSession"].ToString();
            var usr = hcx.Users.Local.FirstOrDefault(u => u.Username.Equals(username)); //todo må hente!
            //u = hcx.Users.Local.Find(u => u.UserName.Equals(userName));
            //må vise alle reservasjonar på brukaren
            if (usr != null)
            {
                hcx.Reservations.Load(); //?

                GridView1.DataSource = (usr as User).Reservations;
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
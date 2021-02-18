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
    public partial class DefaultNy : System.Web.UI.Page
    {

        private HotelContext hcx = new HotelContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            // koble seg opp mot databasen og sjekk om brukeren finnes
            string usrName = UserName.Text.ToString();
            DbSet<User> users = hcx.Users;

            var usrVar = hcx.Users.Local.Where(u => u.Username.Equals(usrName));

            if (usrVar != null)
            {
                HttpContext.Current.Session["UsernameSession"] = usrName;
                Response.Redirect("LoggedIn.aspx");
            }
            else
            {
                //feilmelding: bruker finnes ikke
                UserNotExists.Visible = true;
            }

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //TODO - lag ny bruker og legg denne brukeren til i databasen. 
            User u = new User { Username = NewUserName.Text.ToString(), Name = Name.Text.ToString() };

            var usrVar = hcx.Users.Local.Where(usr => usr.Equals(u));

            if (usrVar == null)
            {
                hcx.Users.Add(u);
                hcx.SaveChanges();

                HttpContext.Current.Session["UsernameSession"] = NewUserName.Text.ToString();
                Response.Redirect("LoggedIn.aspx");
            }
            else
            {
                //feilmelding: bruker finnes allerede
                UserExists.Visible = true;
            }

        }
    }
}
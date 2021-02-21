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
    public partial class _Default : Page
    {
        HotelContext hcx = new HotelContext();

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Login_Click(object sender, EventArgs e)
        {
            // koble seg opp mot databasen og sjekk om brukeren finnes
            string usrName = UserName.Text.ToString();
            //hcx.Users.Load();

            //var usrVar = hcx.Users.Local.FirstOrDefault(u => u.Username.Equals(usrName));
            
            if (WebLoginHelper.CheckIfUsernameExists(usrName, hcx))
            {
                HttpContext.Current.Session["UsernameSession"] = usrName;
                Response.Redirect("LoggedIn2.aspx");
            }
            else
            {
                //feilmelding: bruker finnes ikke hallo
                UserNotExists.Visible = true;
            }

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //TODO - lag ny bruker og legg denne brukeren til i databasen. 
            string username = NewUserName.Text;
            bool usernameExists = WebLoginHelper.CheckIfUsernameExists(username, hcx);
            User u = new User { Username = username, Name = Name.Text };

            //var usrVar = hcx.Users.Local.FirstOrDefault(usr => usr.Equals(u));

            if (!usernameExists)
            {
                hcx.Users.Add(u);
                hcx.SaveChanges();

                WebLoginHelper.SetUsernameInSession(Session, username);
                //HttpContext.Current.Session["UsernameSession"] = NewUserName.Text;
                Response.Redirect("LoggedIn2.aspx");
            }
            else
            {
                //feilmelding: bruker finnes allerede
                UserExists.Visible = true;
                //ny
            }

        }
    }
}
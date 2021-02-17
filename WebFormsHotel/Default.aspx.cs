using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsHotel
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            //TODO - koble seg opp mot databasen og sjekk om brukeren finnes
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //TODO - lag ny bruker og legg denne brukeren til i databasen. 
        }
    }
}
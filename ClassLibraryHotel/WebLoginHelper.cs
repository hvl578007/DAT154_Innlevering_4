using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace ClassLibraryHotel
{
    public class WebLoginHelper
    {
        /// <summary>
        /// Gir tilbake ein user (den som er innlogga) om brukernamnet i session finst, null elles
        /// </summary>
        /// <param name="session"></param>
        /// <param name="hcx"></param>
        /// <returns></returns>
        public static User CheckIfInloggedSession(HttpSessionState session, HotelContext hcx)
        {
            hcx.Users.Load();
            string username = session[SessionUsername]?.ToString();
            if (username == null) return null;
            return hcx.Users.Local.FirstOrDefault(u => u.Username.Equals(username)); //todo må hente!
        }

        //todo putte i hotelcontroller?
        public static bool CheckIfUsernameExists(string username, HotelContext hcx)
        {
            hcx.Users.Load();
            return hcx.Users.Local.FirstOrDefault(u => u.Username.Equals(username)) != null;
        }

        public static string GetUsernameFromSession(HttpSessionState session)
        {
            return session[SessionUsername]?.ToString();
        }

        private static string SessionUsername = "UsernameSession";

        public static void SetUsernameInSession(HttpSessionState session, string username)
        {
            session[SessionUsername] = username;
        }
    }
}

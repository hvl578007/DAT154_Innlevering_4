using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsHotel
{
    public partial class SearchRooms : System.Web.UI.Page
    {
        HotelContext hcx = new HotelContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //endre spørringa mot lista med
            DateTime dateStart = CalendarFrom.SelectedDate;
            DateTime dateEnd = CalendarTo.SelectedDate;
            if (dateEnd.CompareTo(dateStart) < 0)
            {
                //flipp dei to
                DateTime tmp = dateStart;
                dateStart = dateEnd;
                dateEnd = tmp;
            }
            else if (dateEnd.CompareTo(dateStart) == 0)
            {
                //lik dato... validator??
            }

            int beds = int.Parse(TextBoxBeds.Text); //todo exception!!
            int quality = int.Parse(RadioQuality.SelectedValue);

            //finne alle rom, som ikkje har aktiv reservasjon på seg?, altså om det er ein med CheckedIn = true => feil? eller om det finst ein reservasjon som IKKJE har CheckedOut = kan ikkje visa rommet

            hcx.Rooms.Load();
            var avaliableRooms = hcx.Rooms.Local.Where(r =>
            {
                var obj = r.Reservation.FirstOrDefault(res => !res.CheckedOut);
                return obj == null;
            }).ToList();

            if (avaliableRooms != null || avaliableRooms.Count > 0)
            {
                GridViewRooms.DataSource = avaliableRooms;
                GridViewRooms.DataBind();
            } else
            {

            }

        }

        protected void GridViewRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SelectReservation_Click(object sender, EventArgs e)
        {
            //GridViewRooms.SelectedRow;
        }
    }
}
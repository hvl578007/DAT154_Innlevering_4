using ClassLibraryHotel;
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

        private User user = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            User user = WebLoginHelper.CheckIfInloggedSession(Session, hcx);
            
            if (user == null)
            {
                Response.Redirect("Default.aspx");
            }

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

            int beds = int.Parse(DropDownBeds.SelectedValue); //todo exception!!

            int quality = int.Parse(RadioQuality.SelectedValue);//todo exception!!

            //finne alle rom, som ikkje har aktiv reservasjon på seg?, altså om det er ein med CheckedIn = true => feil? eller om det finst ein reservasjon som IKKJE har CheckedOut = kan ikkje visa rommet
            //skal også vise rom som har reservasjon før startdate (og enddate) + reservasjon etter startdate og enddate
            //resDateStart < dateStart && resDateStart > dateEnd && resDateEnd < dateStart && resDateEnd > dateEnd
            //finst før: rDS < DS && rDE < DS
            //finst etter: rDS > DE && rDE > DE

            hcx.Rooms.Load();
            hcx.Reservations.Load();
            var avaliableRooms = hcx.Rooms.Local
                .Where(r => r.NumOfBeds >= beds && r.Size >= quality)
                .Where(r =>
            {
                bool notConflictingRes = r.Reservations.All(res =>
                {
                    bool isBefore = res.DateStart.CompareTo(dateStart) < 0 && res.DateEnd.CompareTo(dateStart) < 0;
                    bool isAfter = res.DateStart.CompareTo(dateEnd) > 0 && res.DateEnd.CompareTo(dateEnd) > 0;
                    return isBefore || isAfter;
                });
                bool emptyRes = r.Reservations.Count == 0 || r.Reservations == null;
                return notConflictingRes || emptyRes;
                //var obj = r.Reservations.FirstOrDefault(res => !res.CheckedOut);
                //return obj == null;
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
            SelectReservation.Visible = true;
        }

        protected void SelectReservation_Click(object sender, EventArgs e)
        {
            DateTime dateStart = CalendarFrom.SelectedDate;
            DateTime dateEnd = CalendarTo.SelectedDate;
            if (dateEnd.CompareTo(dateStart) < 0)
            {
                //flipp dei to
                DateTime tmp = dateStart;
                dateStart = dateEnd;
                dateEnd = tmp;
            }
            string username = HttpContext.Current.Session["UsernameSession"].ToString();
            //GridViewRooms.SelectedRow;
            //må hente ut og lage reservasjon
            Room r = (Room)GridViewRooms.SelectedRow.DataItem;
            Reservation res = new Reservation { CheckedIn = false, CheckedOut = false, DateStart = dateStart, DateEnd = dateEnd, RoomRoomId = r.RoomId, UserUsername=username };
            hcx.Reservations.Add(res);
            hcx.SaveChanges();
        }

        protected void GridViewRooms_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DateTime dateStart = CalendarFrom.SelectedDate;
            DateTime dateEnd = CalendarTo.SelectedDate;
            if (dateEnd.CompareTo(dateStart) < 0)
            {
                //flipp dei to
                DateTime tmp = dateStart;
                dateStart = dateEnd;
                dateEnd = tmp;
            }
            string username = Session["UsernameSession"].ToString();
            //GridViewRooms.SelectedRow;
            //må hente ut og lage reservasjon
            int roomid = int.Parse(GridViewRooms.Rows[e.RowIndex].Cells[1].Text);
            Reservation res = new Reservation { CheckedIn = false, CheckedOut = false, DateStart = dateStart, DateEnd = dateEnd, RoomRoomId = roomid, UserUsername = username };
            hcx.Reservations.Add(res);
            hcx.SaveChanges();

            Response.Redirect("LoggedIn2.aspx");
        }
    }
}
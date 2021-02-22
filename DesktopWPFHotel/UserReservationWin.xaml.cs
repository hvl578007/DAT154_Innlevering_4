using ClassLibraryHotel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for UserReservationWin.xaml
    /// </summary>
    public partial class UserReservationWin : Window
    {
        private String userName;
        private DbSet<Reservation> Reserve;
        public UserReservationWin(HotelContext hcx, String userName)
        {
            InitializeComponent();
            this.userName = userName;
            Reserve = hcx.Set<Reservation>();
            DbSet<User> Users = hcx.Set<User>();
            Users.Load();
            Reserve.Load();

            var reservationList = from us in Users.Local
                                  join res in Reserve.Local
                                  on us.Username equals res.UserUsername
                                  select new { us.Username, res.ReservationId, res.RoomRoomId, res.DateStart, res.DateEnd, res.CheckedIn, res.CheckedOut };

            ReservationList.DataContext = reservationList.Where(n => n.Username.Equals(userName));
        }
    }
}

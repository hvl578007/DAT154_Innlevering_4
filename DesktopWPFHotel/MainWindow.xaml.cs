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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ClassLibraryHotel;

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //databasekopling - bruk hcx!
        private HotelContext hcx = new HotelContext();

        public MainWindow()
        {
            
            InitializeComponent();

            hcx.Rooms.Load();

            //hcx.Rooms.Add(new Room { RoomId = 100, NumOfBeds = 2, Size = 1 });
            //hcx.SaveChanges();

            //lage nytt vindu - burde sende med hcx som parameter til vinduet!
            //new ReservationsWindow(hcx);

        }

        private void UserSearch_Button(object sender, RoutedEventArgs e)
        {
            if (hcx.Users.Find(UserName.Text) != null)
            {
                new UserReservationWin(hcx, UserName.Text).Show();
                this.Close();
            }
            else
            {
                UserName.Text = "Please enter a valid user.";
            }

        }

        private void Reservation_Button(object sender, RoutedEventArgs e)
        {
            new ReservationsWindow(hcx).Show();
            this.Close();
        }

        private void RoomInfo_Button(object sender, RoutedEventArgs e)
        {
            new RoomInfo(hcx).Show();
            this.Close();
        }

        private void AllRoms_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

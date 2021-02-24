using ClassLibraryHotel;
using System;
using System.Collections.Generic;
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

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        private HotelContext hcx = new HotelContext();

        public MainPage()
        {
            InitializeComponent();
        }

        private void UserSearch_Button(object sender, RoutedEventArgs e)
        {
            if (hcx.Users.Find(userNameText.Text) != null)
            {
                ReservationsPage reservationsPage = new ReservationsPage(hcx, userNameText.Text);
                //new UserReservationWin(hcx, userNameText.Text).Show();
                //this.Close();
                this.NavigationService.Navigate(reservationsPage);
            }
            else
            {
                userNameText.Text = "Please enter a valid user.";
            }

        }

        private void Reservation_Button(object sender, RoutedEventArgs e)
        {
            //if (validateForm())
            //{
                ReservationsPage reservationsPage = new ReservationsPage(hcx);
                this.NavigationService.Navigate(reservationsPage);
                //new ReservationsWindow(hcx).Show();
            //}
        }

        private void RoomInfo_Button(object sender, RoutedEventArgs e)
        {
            bool isRoom = int.TryParse(roomNumberText.Text, out int rId);
            Room r = hcx.Rooms.Find(rId);
            if (isRoom && (r != null))
            {
                this.NavigationService.Navigate(new RoomInfoPage(hcx, r));
                
                
            }
            else
            {
                roomNumberText.Text = "Enter a valid roomnumber";
            }
        }

        private void AllRoms_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void newRes_Button(object sender, RoutedEventArgs e)
        {
            //new SearchRooms(hcx);
            SearchRoomsPage searchRoomsPage = new SearchRoomsPage(hcx);
            this.NavigationService.Navigate(searchRoomsPage);
        }

        private bool validateForm()
        {
            bool output = true;
            // legge til flere?

            if (userNameText.Text.Length <= 2 || userNameText.Text.Length > 14)
            {
                output = false;
            }

            return output;
        }

        private void CreateNewRoomBtn_Click(object sender, RoutedEventArgs e)
        {
            NewRoomPage newRoomPage = new NewRoomPage(hcx);
            this.NavigationService.Navigate(newRoomPage);
        }
    }
}

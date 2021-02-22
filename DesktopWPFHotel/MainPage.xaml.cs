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

            if (WebLoginHelper.CheckIfUsernameExists(userNameText.Text, hcx))
            {
                //todo bruk reservationswindow heller her!!
                //new UserReservationWin(hcx, userNameText.Text).Show();
                this.NavigationService.Navigate(new ReservationsPage());
                //this.Close();
            }
            else
            {
                userNameText.Text = "Please enter a valid user.";
            }

        }

        private void Reservation_Button(object sender, RoutedEventArgs e)
        {
            if (true)//validateForm())
            {
                //new ReservationsWindow(hcx).Show();
                ReservationsPage reservationsPage = new ReservationsPage();
                this.NavigationService.Navigate(reservationsPage);
            }
        }

        private void RoomInfo_Button(object sender, RoutedEventArgs e)
        {
            //new RoomInfo(hcx).Show();
            //this.Close();
            RoomInfoPage roomInfoPage = new RoomInfoPage();
            this.NavigationService.Navigate(roomInfoPage);
        }

        private void AllRoms_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void newRes_Button(object sender, RoutedEventArgs e)
        {
            //new SearchRooms(hcx);
            SearchRoomsPage searchRoomsPage = new SearchRoomsPage();
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
    }
}

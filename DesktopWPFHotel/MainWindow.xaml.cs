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

        private void Reservation_Button(object sender, RoutedEventArgs e)
        {
            if (validateForm())
            { 
            new ReservationsWindow(hcx);
            }
        }

        private void RoomInfo_Button(object sender, RoutedEventArgs e)
        {
            new RoomInfo(hcx);
        }

        private void newRes_Button(object sender, RoutedEventArgs e)
        {
            new SearchRooms(hcx);
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

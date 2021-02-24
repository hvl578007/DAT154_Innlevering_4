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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for ReservationsPage.xaml
    /// </summary>
    public partial class ReservationsPage : Page
    {
        private HotelContext hcx;
        private Reservation selectedRes;
        private Room selectedAvbRoom;
        private string username;

        public ReservationsPage(HotelContext hcx)
        {

            InitializeComponent();

            hcx.Reservations.Load();

            this.hcx = hcx;

            var res = hcx.Reservations;

            ResList.DataContext = res.Local;

            ResList.SelectionChanged += ResList_SelectionChanged;
            AvailableRooms.SelectionChanged += AvailableRooms_SelectionChanged;
        }


        public ReservationsPage(HotelContext hcx, string usr)
        {
            InitializeComponent();

            hcx.Users.Load();

            this.hcx = hcx;

            var user = hcx.Users.Local.FirstOrDefault(u => u.Username.Equals(usr));

            ResList.DataContext = user.Reservations;

            ResList.SelectionChanged += ResList_SelectionChanged;
            AvailableRooms.SelectionChanged += AvailableRooms_SelectionChanged;
        }

        private void ResList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();

            if ((sender as ListView).SelectedIndex != -1)
            {
                if (ContentGrid.Visibility is Visibility.Hidden) ContentGrid.Visibility = Visibility.Visible;
                selectedRes = (sender as ListView).SelectedItem as Reservation;
                ResId.Text = ((sender as ListView).SelectedItem as Reservation).ReservationId.ToString();
                RoomId.Text = ((sender as ListView).SelectedItem as Reservation).Room.RoomId.ToString();

                if (selectedRes.CheckedIn == true)
                {
                    CheckIn.Content = "Check out";
                }
                else
                {
                    CheckIn.Content = "Check In";
                }

                AvbRoomsTxt.Visibility = Visibility.Hidden;
                AvailableRooms.Visibility = Visibility.Hidden;
            }

        }

        private void AvailableRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //throw new NotImplementedException();

            if((sender as ListView).SelectedIndex != -1)
            {
                selectedAvbRoom = (sender as ListView).SelectedItem as Room;
                ChangeRoomBtn.Visibility = Visibility.Visible;
            }
            else
            {
                ChangeRoomBtn.Visibility = Visibility.Hidden;
            }

        }

        private void ChangeRoom_Click(object sender, RoutedEventArgs e)
        {
            selectedRes.RoomRoomId = selectedAvbRoom.RoomId;
            hcx.SaveChanges();

            AvailableRooms.DataContext = null;

            RoomId.Text = selectedRes.RoomRoomId.ToString();

            AvailableRooms.Visibility = Visibility.Hidden;
            ChangeRoomBtn.Visibility = Visibility.Hidden;
            AvbRoomsTxt.Visibility = Visibility.Hidden;
        }

        private void AvbRooms_Click(object sender, RoutedEventArgs e)
        {
            //søk på ledige rom og så bytt til valgt rom
            List<Room> availableRooms = HotelController.RetrieveAvaliableRooms(hcx, selectedRes.DateStart, selectedRes.DateEnd);

            AvailableRooms.DataContext = availableRooms;

            AvbRoomsTxt.Visibility = Visibility.Visible;
            AvailableRooms.Visibility = Visibility.Visible;

        }

        private void CheckIn_Click(object sender, RoutedEventArgs e)
        {

            if (selectedRes.CheckedIn == false)
            {
                selectedRes.CheckedIn = true;
                hcx.SaveChanges();

                //skjul høyresiden etterpå
                ContentGrid.Visibility = Visibility.Hidden;

            }
            else
            {
                selectedRes.CheckedOut = true;

                //ny cleaning task
                selectedRes.Room.Tasks.Add(new ClassLibraryHotel.Task { 
                    Note="", 
                    Info="Cleaning", 
                    State=0, 
                    Type=0, 
                    RoomRoomId=selectedRes.Room.RoomId }
                );

                hcx.SaveChanges();

                CheckIn.Visibility = Visibility.Hidden;
                othrAvbRooms.Visibility = Visibility.Hidden;
                //TODO fiks er ikke blitt visible hvis en velger ny reservasjon!! sjekk når en velger ny reservasjon
                //sjekk ut knappen og endre rom knappen blir hidden. må også gjøres i konstruktørene? 
                //skriv at en er blitt sjekket ut oppdater listen 

            }

            ResList.DataContext = null;

            if (username == null)
            {
                hcx.Reservations.Load();
                var oppdatertRes = hcx.Reservations;
                ResList.DataContext = oppdatertRes.Local;
            }
            else
            {
                hcx.Users.Load();
                var user = hcx.Users.Local.FirstOrDefault(u => u.Username.Equals(username));
                ResList.DataContext = user.Reservations;
            }
        }
    }
}

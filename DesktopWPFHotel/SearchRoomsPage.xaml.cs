﻿using System;
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
using ClassLibraryHotel;

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for SearchRoomsPage.xaml
    /// </summary>
    public partial class SearchRoomsPage : Page
    {
        HotelContext hcx = new HotelContext();
        public SearchRoomsPage()
        {
            InitializeComponent();
        }

        public SearchRoomsPage(HotelContext hcx)
        {
            InitializeComponent();
            this.hcx = hcx;
            roomList.SelectionChanged += RoomList_SelectionChanged;
            newUserCombo.SelectionChanged += NewUserCombo_SelectionChanged;
        }

        private void NewUserCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (newUserCombo.SelectedIndex != -1)
            {

                userNameText.Visibility = Visibility.Visible;

                if (newUserCombo.SelectedIndex == 0)
                {
                    nameText.Visibility = Visibility.Visible;
                } else if (newUserCombo.SelectedIndex == 1)
                {
                    nameText.Visibility = Visibility.Hidden;
                }
            } else
            {
                userNameText.Visibility = Visibility.Hidden;
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            DateTime dateStart = CalendarFrom.SelectedDate.GetValueOrDefault();
            DateTime dateEnd = CalendarTo.SelectedDate.GetValueOrDefault();

            if (dateStart == null || dateEnd == null)
            {
                return;
            }

            if (dateEnd.CompareTo(dateStart) < 0)
            {
                DateTime tmp = dateStart;
                dateStart = dateEnd;
                dateEnd = tmp;
            }
            else if (dateEnd.CompareTo(dateStart) == 0 || dateEnd == DateTime.MinValue || dateStart == DateTime.MinValue)
            {
                return;
            }

            int beds = int.Parse((numberOfBeds.SelectedItem as ComboBoxItem).Tag.ToString()); //Usikker om detta er riktig
            //stian har endra -> må hente ut selecteditem som comboboxitem og så hente ut tag

            int quality = 0;
            //var checkedValue = (panel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value));
            if (radioBTNok.IsChecked == true)
            {
                quality = 0;
            } 
            else if (radioBTNgood.IsChecked == true)
            {
                quality = 1;
            }
            else if (radioBTNamazing.IsChecked == true)
            {
                quality = 2;
            }


            List<Room> availableRooms = HotelController.RetrieveAvaliableRooms(hcx, beds, quality, dateStart, dateEnd);

            roomList.DataContext = availableRooms;
            
            // Mer her? Hvordan "selecte" etter man får opp lista med ledige rom?
        }

        
        private void RoomList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //her kan ein vise knappen etter ein har valt ein ting - metoden blir køyrd når ein trykkar på eit av felta i listview

            //index == -1 betyr ikkje valt noko
            if (roomList.SelectedIndex == -1)
            {
                submitButton.Visibility = Visibility.Hidden;
            } else
            {
                submitButton.Visibility = Visibility.Visible;
            }
        }

        protected void bookButton_Click(object sender, EventArgs e)
        {

            //selected room:
            Room selectedRoom = roomList.SelectedItem as Room;
            int roomId = selectedRoom.RoomId;

            String name = nameText.Text;
            String username = userNameText.Text;

 
            DateTime dateStart = CalendarFrom.SelectedDate.GetValueOrDefault();
            DateTime dateEnd = CalendarTo.SelectedDate.GetValueOrDefault();

            //lag user først (med username og name) 
            User user = new User { Name = name, Username = username };
            //lag så reservation (kommenter vekk under):
            Reservation res = new Reservation { DateStart = dateStart, DateEnd = dateEnd, CheckedIn = false, CheckedOut = false, RoomRoomId = roomId, UserUsername = username };
            var dbUser = hcx.Users.Find(username);

            if (newUserCombo.SelectedIndex == 1)
            {
                if (dbUser != null)
                {
                    hcx.Reservations.Add(res);
                    hcx.SaveChanges();
                    resetForm();
                }
                else
                {
                    errorInput.Visibility = Visibility.Visible;
                    userNameText.Text = "Username";
                    errorInput.Text = "User does not exist";
                }
            }
            else if (newUserCombo.SelectedIndex == 0)
            {
                if (dbUser == null)
                {
                    hcx.Users.Add(user);
                    hcx.Reservations.Add(res);
                    hcx.SaveChanges();
                    resetForm();
                }
                else
                {
                    errorInput.Visibility = Visibility.Visible;
                    userNameText.Text = "Username";
                    errorInput.Text = "User already exist";
                }
            }
            
        }

        protected void resetForm()
        {
            userNameText.Clear();
            numberOfBeds.SelectedItem = -1;
            radioBTNok.IsChecked = true;
            radioBTNgood.IsChecked = false;
            radioBTNamazing.IsChecked = false;
            CalendarFrom.DisplayDate = DateTime.Now;
            CalendarTo.DisplayDate = DateTime.Now;
            roomList.SelectedItem = -1;
            submitButton.Visibility = Visibility.Hidden;
            errorInput.Visibility = Visibility.Hidden;
            newUserCombo.SelectedIndex = 0;
            roomList.DataContext = null;
            userNameText.Text = "Username";
            nameText.Text = "Name";
        }

    }
}

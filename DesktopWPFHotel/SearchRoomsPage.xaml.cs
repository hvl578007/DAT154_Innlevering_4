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
            // Motta data fra over etter å ha "selected" rom
            // Må så lagre data i database
            //hent data i frå felt igjen (gjer som over)
            //selected room:
            Room selectedRoom = roomList.SelectedItem as Room;
            int roomId = selectedRoom.RoomId;

            //hent namn + username
            String name = nameText.Text;
            String username = userNameText.Text;

            //hent dateend + datestart igjen
            DateTime dateStart = CalendarFrom.SelectedDate.GetValueOrDefault();
            DateTime dateEnd = CalendarTo.SelectedDate.GetValueOrDefault();

            //lag user først (med username og name) (kommenter vekk under:
            User user = new User { Name = name , Username = username};
            //lag så reservation (kommenter vekk under):
            Reservation res = new Reservation { DateStart = dateStart , DateEnd = dateEnd, CheckedIn = false, CheckedOut = false, RoomRoomId = roomId, UserUsername = username};

            //legg til i databasen og lagrar (kommenter vekk under):
            hcx.Users.Add(user);
            hcx.Reservations.Add(res);
            hcx.SaveChanges();

            //burde fjerne tekst og valt ting i felt her igjen / evt ei startside
            resetForm();
                


        }

        protected void resetForm()
        {
            userNameText.Clear();
            nameText.Clear();
            numberOfBeds.SelectedItem = -1;
            radioBTNok.IsChecked = true;
            radioBTNgood.IsChecked = false;
            radioBTNamazing.IsChecked = false;
            CalendarFrom.DisplayDate = DateTime.Now;
            CalendarTo.DisplayDate = DateTime.Now;
            roomList.SelectedItem = -1;
            submitButton.Visibility = Visibility.Hidden;
        }

    }
}

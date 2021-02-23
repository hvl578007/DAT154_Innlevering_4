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
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            DateTime dateStart = (DateTime)CalendarFrom.SelectedDate;
            DateTime dateEnd = (DateTime)CalendarTo.SelectedDate;

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

            int beds = int.Parse(numberOfBeds.Tag.ToString()); //Usikker om detta er riktig

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

        protected void bookButton_Click(object sender, EventArgs e)
        {
            // Motta data fra over etter å ha "selected" rom
            // Må så lagre data i database
        }

    }
}

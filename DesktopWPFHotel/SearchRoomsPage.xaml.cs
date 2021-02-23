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

        protected void BookButton_Click(object sender, EventArgs e)
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

            int beds = int.Parse(numberOfBeds.Tag.ToString()); 



        }
    }
}

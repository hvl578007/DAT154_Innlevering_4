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
using System.Windows.Shapes;
using ClassLibraryHotel;

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for ReservationsWindow.xaml
    /// </summary>
    public partial class ReservationsWindow : Window
    {
        private hotelEntities1 hcx = new hotelEntities1();

        public ReservationsWindow()
        {
            InitializeComponent();
        }

        public ReservationsWindow(hotelEntities1 hcx)
        {
            InitializeComponent();
            
        }
    }
}

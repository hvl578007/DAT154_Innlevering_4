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
    public partial class MainWindow : NavigationWindow
    {
        //databasekopling - bruk hcx!

        public MainWindow()
        {
            
            InitializeComponent();

            //hcx.Rooms.Load();

            //hcx.Rooms.Add(new Room { RoomId = 100, NumOfBeds = 2, Size = 1 });
            //hcx.SaveChanges();

            //lage nytt vindu - burde sende med hcx som parameter til vinduet!
            //new ReservationsWindow(hcx);

        }

        
    }
}

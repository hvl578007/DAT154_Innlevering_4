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
    /// Interaction logic for NewRoomPage.xaml
    /// </summary>
    public partial class NewRoomPage : Page
    {
        HotelContext hcx;
        //Room room;
        public NewRoomPage(HotelContext hcx)
        {
            InitializeComponent();
            this.hcx = hcx;
            //room = new Room();
            //NewRoomStack.DataContext = room;
        }

        private void BtnCreateNewRoom_Click(object sender, RoutedEventArgs e)
        {
            //int roomid = int.Parse(TextRoomId.Text);
            bool ok = int.TryParse(TextRoomBeds.Text, out int roombeds);
            int.TryParse((ComboRoomQuality.SelectedItem as ComboBoxItem).Tag.ToString(), out int roomquality);
            if (!ok)
            {
                TextRoomBeds.Text = "Error, not a number";
                ComboRoomQuality.SelectedIndex = -1;
                return;
            }
            hcx.Rooms.Load();
            //var existingRoom = hcx.Rooms.Where(r => r.RoomId == roomid).FirstOrDefault();
            //if (existingRoom == null)
            //{
            Room room = new Room { NumOfBeds=roombeds, Size=roomquality};
            hcx.Rooms.Add(room);
            hcx.SaveChanges();
            //RoomIDErrorLabel.Visibility = Visibility.Hidden;
            //TextRoomId.Text = "";
            TextRoomBeds.Text = "";
            ComboRoomQuality.SelectedIndex = -1;
            //}
            //else
            //{
                //TextRoomId.Text = "";
                //RoomIDErrorLabel.Visibility = Visibility.Visible;
            //}
        }
    }
}

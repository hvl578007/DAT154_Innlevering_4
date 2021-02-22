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
using System.Windows.Shapes;
using ClassLibraryHotel;
using Task = ClassLibraryHotel.Task;

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for RoomInfo.xaml
    /// </summary>

    public partial class RoomInfo : Window
    {
        private DbSet<Room> rooms;
        private DbSet<Task> tasks;

        public RoomInfo(HotelContext hcx, int RoomId)
        {
            InitializeComponent();
            
            rooms = hcx.Set<Room>();
            tasks = hcx.Set<Task>();

            Room SearchRoom = rooms.Find(RoomId);
            tasks.Load();

            RoomInf.DataContext = SearchRoom;
            TaskList.DataContext = from tk in tasks.Local
                                   where tk.RoomRoomId.Equals (SearchRoom.RoomId)
                                   select new {tk.Info, tk.Note, tk.State, tk.Type };

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

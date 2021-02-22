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
using Task = ClassLibraryHotel.Task;

namespace DesktopWPFHotel
{
    /// <summary>
    /// Interaction logic for RoomInfoPage.xaml
    /// </summary>
    public partial class RoomInfoPage : Page
    {
        private DbSet<Room> rooms;
        private DbSet<Task> tasks;

        public RoomInfoPage(HotelContext hcx)
        {
            InitializeComponent();

            rooms = hcx.Set<Room>();
            tasks = hcx.Set<Task>();

            rooms.Load();
            tasks.Load();



            var taskList = from rm in rooms.Local
                           join tk in tasks.Local
                           on rm.RoomId equals tk.RoomRoomId
                           select new { rm.RoomId, rm.NumOfBeds, rm.Size, tk.Info, tk.Note, tk.State, tk.Type };

            RoomList.DataContext = taskList;
        }
    }
}
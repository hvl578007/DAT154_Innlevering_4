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
        private Room r;
        private DbSet<Task> tasks;

        public RoomInfo(HotelContext hcx, Room r )
        {
            InitializeComponent();
            this.r = r;
            tasks = hcx.Set<Task>();
            tasks.Load();

            RoomNumber.Text += r.RoomId;
            Beds.Text += r.NumOfBeds;
            Size.Text += r.Size;
            Task t = new ClassLibraryHotel.Task { TaskId = 2, Note = "Hi", Info = "Some info", State = 0, Type = 0, RoomRoomId = 1, Room = r };
            tasks.Add(new ClassLibraryHotel.Task { TaskId = 1, Note = "Something", Info = "Info", State = 0, Type = 0, RoomRoomId = 1, Room = r });
            tasks.Add(t);
            tasksList.DataContext = r.Tasks;
            }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //task id
            tasks.Find(1).Info = AddInfo.Text;
            tasksList.DataContext = r.Tasks;
        }
    }
}

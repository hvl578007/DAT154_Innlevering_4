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
        private Room r;
        private DbSet<Task> tasks;
        Task t;
        HotelContext hcx;
        public RoomInfoPage(HotelContext hcx, Room r)
        {
            InitializeComponent();
            this.hcx = hcx;
            this.r = r;
            tasks = hcx.Set<Task>();
            tasks.Load();

            RoomNumber.Text += r.RoomId;
            Beds.Text += r.NumOfBeds;
            Size.Text += r.Size;
            tasksList.DataContext = r.Tasks;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            String n = AddNotes.Text;
            String i = AddInfo.Text;
            int taskType = TaskType.SelectedIndex + 1;
            int taskState = TaskState.SelectedIndex;
            if (taskState == -1)
            {
                taskState = 0;
            }

            if (taskType != 1 && taskType!=2)
            {
                TTNS.Visibility = Visibility.Visible;
            }
            else
            {
                if (t == null)
                {
                    t = new ClassLibraryHotel.Task();
                    t.Note = n;
                    t.Info = i;
                    t.Type = taskType;
                    t.State = taskState;
                    t.Room = r;
                    t.RoomRoomId = r.RoomId;

                    tasks.Add(t);
                    hcx.SaveChanges();
                    tasksList.DataContext = null;
                    tasksList.DataContext = r.Tasks;
                }
                else
                {
                    t.Note = n;
                    t.Info = i;
                    t.Type = taskType;
                    t.State = taskState;
                    hcx.SaveChanges();
                    tasksList.DataContext = null;
                    tasksList.DataContext = r.Tasks;
                }

                Reset();

                //Må oppdatere viduet slik at nye tasks vises.

            }
        }


        private void TaskList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            t = (Task)tasksList.SelectedItem;
            AddNotes.Text = t.Note;
            AddInfo.Text = t.Info;
            TaskType.SelectedIndex = t.Type-1;
            TaskState.SelectedIndex = t.State;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            AddNotes.Text = "";
            AddInfo.Text = "";
            TaskType.SelectedIndex = -1;
            TaskState.SelectedIndex = -1;
            t = null;
            TTNS.Visibility = Visibility.Hidden;
        }
    }
}
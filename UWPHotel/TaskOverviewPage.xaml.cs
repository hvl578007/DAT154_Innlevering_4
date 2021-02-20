using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using ClassLibraryStandardHotel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPHotel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskOverviewPage : Page
    {
        private TaskType type;
        private int id = -1;
        private HttpClient client;
        private string baseUri = "http://localhost:49689/api";
        List<Object> tasks;
        List<HotelTask> hotelTasks;

        public TaskOverviewPage()
        {
            this.InitializeComponent();
            
            //REST API / WEB API hente tasks - TODO!
            /*
            client = new HttpClient();

            var response = "";
            System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Run(async () =>
            {
                response = await client.GetStringAsync(new Uri(baseUri + "/Tasks"));
            });
            task.Wait();
            List<HotelTask> hotelTasks = JsonConvert.DeserializeObject<List<HotelTask>>(response);

            //om ein seier at ein har fått alle tasks nå...
            List<HotelTask> newTasks = hotelTasks.Where(t => t.Type == id).ToList();
            */

            hotelTasks = makeDummyTasks();
            var onlyForThisTasks = hotelTasks.Where(t => t.Type == (int)type);
            //connect tasks to gridview etc!
            TaskList.ItemsSource = onlyForThisTasks;
            //TaskList.ItemClick += TaskList_ItemClick;
            TaskList.SelectionChanged += TaskList_SelectionChanged;
            TaskList.IsItemClickEnabled = true;
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContentGrid.Visibility == Visibility.Collapsed) ContentGrid.Visibility = Visibility.Visible;
            var selectedItem = (sender as ListView).SelectedItem as HotelTask;
            TextTaskInfo.Text = ((sender as ListView).SelectedItem as HotelTask).Info;
            TextTaskState.Text = ((TaskState)selectedItem.State).ToString();
            TextBoxTaskNotes.Text = selectedItem.Note;
            ComboTaskState.SelectedIndex = -1;
        }

        private void TaskList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ContentGrid.Visibility == Visibility.Collapsed) ContentGrid.Visibility = Visibility.Visible;
            if (sender is HotelTask) TextTaskInfo.Text = (sender as HotelTask)?.Info;
            //throw new NotImplementedException();
        }

        private List<HotelTask> makeDummyTasks()
        {
            List<HotelTask> list = new List<HotelTask>
            {
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 1", RoomRoomId=1, TaskId=1, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=20, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=21, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=22, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=23, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=24, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=25, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=26, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=27, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=28, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=29, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=30, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=31, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=32, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=33, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=34, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=35, Note=""},
                new HotelTask{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=2, Note=""},
                new HotelTask{Type=(int)TaskType.RoomService, State=0, Info="Dummyinfo roomservice 3", RoomRoomId=1, TaskId=3, Note=""},
                new HotelTask{Type=(int)TaskType.RoomService, State=0, Info="Dummyinfo roomservice 4", RoomRoomId=2, TaskId=4, Note=""},
                new HotelTask{Type=(int)TaskType.Maintenace, State=0, Info="Dummyinfo maintenace 5", RoomRoomId=1, TaskId=5, Note=""},
                new HotelTask{Type=(int)TaskType.Maintenace, State=0, Info="Dummyinfo maintenace 6", RoomRoomId=2, TaskId=6, Note=""}
            };
            return list;
        }

        private async void RefreshTasks()
        {
            var response = "";

            response = await client.GetStringAsync(new Uri(baseUri + "/Tasks"));

            tasks = JsonConvert.DeserializeObject<List<Object>>(response);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            

            //RefreshTasks();

            if (this.id != (int)e.Parameter)
            {
                this.id = (int)e.Parameter;
                this.type = (TaskType)(int)e.Parameter;
                TaskList.ItemsSource = hotelTasks.Where(t => t.Type == (int)type);
                switch (type)
                {
                    case TaskType.CleaningService:
                        WelcomeText.Text = "Cleaning service page";
                        break;

                    case TaskType.RoomService:
                        WelcomeText.Text = "Room service page";
                        break;

                    case TaskType.Maintenace:
                        WelcomeText.Text = "Maintenance service page";
                        break;
                    default:
                        WelcomeText.Text = "Error...";
                        break;
                }
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    class HotelTask
    {
        public int TaskId { get; set; }
        public string Note { get; set; }
        public string Info { get; set; }
        public int State { get; set; }
        public int Type { get; set; }
        public int RoomRoomId { get; set; }
    }

}

/*
private async Task<string> GetAllTasks()
{
    Task<string> ret = null;
    using (var httpClient = new HttpClient())
    {
        try
        {
            ret = new Task<string>(await httpClient.GetStringAsync(new Uri(baseUri + "/Tasks")));
        }
        catch (Exception e)
        {
            //e.Message;
        }
    }
    //string result = await client.GetStringAsync(new Uri(baseUri + "/Tasks"));
    return ret;
}
*/
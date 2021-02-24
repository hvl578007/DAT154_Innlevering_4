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
        private string baseUri = "http://localhost:49689/api";
        private Uri getTasksUri = new Uri("http://localhost:49689/api/Tasks");

        List<HotelTaskUWP> tasks;

        public TaskOverviewPage()
        {
            this.InitializeComponent();

            //set opp litt events
            TaskList.SelectionChanged += TaskList_SelectionChanged;

            ComboTaskState.SelectionChanged += ComboTaskState_SelectionChanged;
        }

        private void ComboTaskState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTaskButton.Visibility = Visibility.Visible;
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedIndex != -1)
            {
                if (ContentGrid.Visibility == Visibility.Collapsed) ContentGrid.Visibility = Visibility.Visible;
                var selectedItem = (sender as ListView).SelectedItem as HotelTaskUWP;
                TextTaskInfo.Text = ((sender as ListView).SelectedItem as HotelTaskUWP).Info;
                TextTaskState.Text = ((TaskState)selectedItem.State).ToString();
                TextBoxTaskNotes.Text = selectedItem.Note;
                ComboTaskState.SelectedIndex = -1;
                UpdateTaskButton.Visibility = Visibility.Collapsed;
            }
        }

        /*
        private List<HotelTaskUWP> makeDummyTasks()
        {
            List<HotelTaskUWP> list = new List<HotelTaskUWP>
            {
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 1", RoomRoomId=1, TaskId=1, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=20, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=21, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=22, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=23, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=24, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=25, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=26, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=27, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=28, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=29, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=30, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=31, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=32, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=33, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=34, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=35, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.CleaningService, State=0, Info="Dummyinfo Cleaning 2", RoomRoomId=2, TaskId=2, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.RoomService, State=0, Info="Dummyinfo roomservice 3", RoomRoomId=1, TaskId=3, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.RoomService, State=0, Info="Dummyinfo roomservice 4", RoomRoomId=2, TaskId=4, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.Maintenace, State=0, Info="Dummyinfo maintenace 5", RoomRoomId=1, TaskId=5, Note=""},
                new HotelTaskUWP{Type=(int)TaskType.Maintenace, State=0, Info="Dummyinfo maintenace 6", RoomRoomId=2, TaskId=6, Note=""}
            };
            return list;
        }
        */

        private async Task RefreshTasksOverWebAPI()
        {
            var response = "";
            using (var httpClient = new HttpClient())
            {
                response = await httpClient.GetStringAsync(getTasksUri);
            }

            tasks = JsonConvert.DeserializeObject<List<HotelTaskUWP>>(response);

            TaskList.ItemsSource = tasks?.Where(t => t.Type == (int)type && t.State < (int)TaskState.Finished);

            LoadingText.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadingText.Visibility = Visibility.Visible;
            ErrorUpdatingText.Visibility = Visibility.Collapsed;

            Task netTask = RefreshTasksOverWebAPI();

            base.OnNavigatedTo(e);

            if (this.id != (int)e.Parameter)
            {
                this.id = (int)e.Parameter;
                this.type = (TaskType)(int)e.Parameter;

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
            LoadingText.Visibility = Visibility.Visible;
            ContentGrid.Visibility = Visibility.Collapsed;
            Task netTask = RefreshTasksOverWebAPI();
        }

        private void UpdateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            HotelTaskUWP taskToBeUpdated = TaskList.SelectedItem as HotelTaskUWP;
            taskToBeUpdated.State = int.Parse((ComboTaskState.SelectedItem as ComboBoxItem).Tag.ToString());
            taskToBeUpdated.Note = TextBoxTaskNotes.Text + "";
            Task<bool> t = UpdateTaskOverWebAPI(taskToBeUpdated);
        }

        private async Task<bool> UpdateTaskOverWebAPI(HotelTaskUWP ht)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(new Uri(baseUri + "/Tasks/" + ht.TaskId.ToString()), new HttpStringContent(JsonConvert.SerializeObject(ht, Formatting.Indented), Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    ErrorUpdatingText.Visibility = Visibility.Visible;
                    return false;
                } else
                {
                    TaskList_SelectionChanged(TaskList, null);
                    return true;
                }
            }
        }
    }
}
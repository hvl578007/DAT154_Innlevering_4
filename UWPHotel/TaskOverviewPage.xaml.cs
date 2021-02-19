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

using HotelTask2 = ClassLibraryStandardHotel.Task;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPHotel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskOverviewPage : Page
    {
        private int id;
        private HttpClient client;
        private string baseUri = "http://localhost:49689/api";
        List<Object> tasks;

        public TaskOverviewPage()
        {
            this.InitializeComponent();
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
            //connect tasks to gridview etc!
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
            this.id = (int)e.Parameter;
            switch (this.id)
            {
                case 0:
                    WelcomeText.Text = "Cleaning service page";
                    break;

                case 1:
                    WelcomeText.Text = "Room service page";
                    break;

                case 2:
                    WelcomeText.Text = "Maintenance service page";
                    break;
                default:
                    WelcomeText.Text = "Error...";
                    break;
            }

        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
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
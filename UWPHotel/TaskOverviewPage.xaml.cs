using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPHotel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskOverviewPage : Page
    {
        private int id;

        public TaskOverviewPage()
        {
            this.InitializeComponent();
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
}

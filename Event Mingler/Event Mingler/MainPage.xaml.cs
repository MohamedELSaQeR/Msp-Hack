using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Event_Mingler
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.MyFrame.Navigate(typeof(Views.Home_Page));
            MySplitViev.DisplayMode = SplitViewDisplayMode.Overlay;
            MySplitViev.IsPaneOpen = false;
        }

        private async void Home_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            if (button != null)
            {
                switch (button.Content.ToString())
                {
                    case "Home":
                        this.MyFrame.Navigate(typeof(Views.Home_Page));
                        break;
                    case "Feedback":
                        //feedbackButton_Click();
                        await Launcher.LaunchUriAsync(new Uri(string.Format("ms-windows-store:REVIEW?PFN={0}", Windows.ApplicationModel.Package.Current.Id.FamilyName)));
                        break;
                    case "Settings":
                        this.MyFrame.Navigate(typeof(Views.Settings_Page));
                        break;
                }
                MySplitViev.IsPaneOpen = false;
                Header.Text = button.Content.ToString();
            }
        }
        private async void feedbackButton_Click()
        {
            await Microsoft.Services.Store.Engagement.Feedback.LaunchFeedbackAsync();
        }
        private void SplitTogleBtn_Click(object sender, RoutedEventArgs e)
        {
            MySplitViev.IsPaneOpen = !MySplitViev.IsPaneOpen;
        }
    }
}

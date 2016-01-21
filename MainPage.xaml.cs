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
using Windows.System.Profile;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;
using System.Diagnostics;
using Windows.Storage;
using BallDrive.Data;
using BallDrive.Data.Notifications;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BallDrive
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public string deviceType { get { return deviceTypeCheck(); } set { } }

        public MainPage()
        {
            setResolution();
            this.InitializeComponent();

        }

        public void startNewGame(object sender, RoutedEventArgs args)
        {
            // Game starten
            this.Frame.Navigate(typeof(NewGamePage), null);
        }
        
        public void exitGame(object sender, RoutedEventArgs args)
        {
            Application.Current.Exit();
        }

        public void settings(object sender, RoutedEventArgs args)
        {
            // Game starten
            this.Frame.Navigate(typeof(AppSettings), null);
        }

        public string deviceTypeCheck()
        {
            string deviceType = AnalyticsInfo.VersionInfo.DeviceFamily;

            if (deviceType.Contains("Desktop"))
                return "Desktop";
            else if (deviceType.Contains("Mobile"))
                return "Mobile";

            return "No device type found";
        }

        public void setResolution()
        {
            if (deviceType == "Desktop")
                ApplicationView.PreferredLaunchViewSize = new Size(600, 800);
            else if (deviceType == "Mobile")
                ApplicationView.PreferredLaunchViewSize = new Size(200, 300);
            
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameInfoPage), null);
        }

        private void Grid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }
    }
}

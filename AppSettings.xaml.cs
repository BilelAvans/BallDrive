using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BallDrive
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppSettings : Page
    {

        public static ApplicationData AppData = ApplicationData.Current;
        public static ApplicationDataContainer AppDataContainer = AppData.LocalSettings;

        public List<Color> Colours { get; set; }

        public AppSettings()
        {
            addColors();
            this.InitializeComponent();

        }

        public void addColors()
        {
            Colours = new List<Color>();
            Colours.Add(Colors.Black);
            Colours.Add(Colors.Yellow);
            Colours.Add(Colors.Green);
            Colours.Add(Colors.DarkBlue);
            Colours.Add(Colors.Violet);
        }

        private void Grid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            // Save settings to app data on change
            Save_Local();
            this.Frame.Navigate(typeof(MainPage), null);
        }

        private void Save_Local()
        {
            if (PreferredUserNameBox.Text.Length > 0)
                AppDataContainer.Values["username"] = PreferredUserNameBox.Text;

        }

        private void ListBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Debug.WriteLine("Writing");
            ListBoxItem item = (ListBoxItem)sender;
            Color ourcolor = ((SolidColorBrush)item.Background).Color;
            AppDataContainer.Values["prefcolorR"] = ourcolor.R;
            AppDataContainer.Values["prefcolorG"] = ourcolor.G;
            AppDataContainer.Values["prefcolorB"] = ourcolor.B;
        }
    }
}

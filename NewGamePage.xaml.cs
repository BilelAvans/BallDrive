using BallDrive.Data.Controls;
using BallDrive.Data.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BallDrive
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewGamePage : Page
    {

        public NoteQueue nQueue { get; set; } = new NoteQueue();
        public NewGamePage()
        {
            this.InitializeComponent();
            
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)diffSelection.SelectedItem;
            if (selectedItem == null)
                nQueue.Enqueue(new Note("Set difficulty", "No difficulty set, please select one"));
            else {
                string content = (string)selectedItem.Content;
                this.Frame.Navigate(typeof(GameView), new Tuple<DifficultySettings.DIFFICULTY>(DifficultySettings.stringToDiff(content)));
            }
        }

        private void notificationReadButton_Click(object sender, RoutedEventArgs e)
        {
            nQueue.Push();
        }
    }
}

using BallDrive.Data.Notifications;
using BallDrive.Data.Scores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
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
    public sealed partial class HighScoreView : Page
    {

        private List<HighScore> Scores;

        private HighScore personalScore;

        public List<HighScore> TOP7 { get { return Scores.Where(score => score.Difficulty.Equals(personalScore.Difficulty)).OrderByDescending(score => score.Score).Take(7).ToList(); } }

        public HighScoreView()
        {
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;

            this.InitializeComponent();
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.KeyStatus.ScanCode)
            {
                case 14: this.Frame.Navigate(typeof(MainPage), null); break;
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Scores = new List<HighScore>();
            // Get played game highscore
            personalScore = e.Parameter as HighScore;

            Scores.Add(personalScore);
            // Get saved highscores

            try
            {
                Scores.AddRange(await ScoreDB.loadScores());
            }
            catch (NullReferenceException ex)
            {
                Debug.Write(ex.Message);
            }

            if (Scores.Where(sc => sc.Difficulty.Equals(personalScore.Difficulty)).Max(sc => sc.Score) <= personalScore.Score)
            {
                Notification.sendNote(Notification.standardNotification("Highscore", "Congratulations, you're leading with " + personalScore.Score + " Points on "+ personalScore.Difficulty));
            }

            ScoreDB.saveScores(Scores);
        }

        
        private async void Grid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                this.Frame.Navigate(typeof(MainPage), null);
            });
        }
    }
}

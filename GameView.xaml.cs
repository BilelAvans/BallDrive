using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BallDrive.Data.Games;
using BallDrive.Data;
using BallDrive.Data.Scores;
using BallDrive.Data.Controls;
using Windows.UI.ViewManagement;
using BallDrive.Data.Characters;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using BallDrive.Data.Notifications;
using BallDrive.Data.Characters.Enemies;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BallDrive
{
    public sealed partial class GameView : Page
    {

        public Game CurrentGame { get; set; }
        private KeyHandler kHandler { get; set; }

        public NoteQueue nQueue = new NoteQueue();
        private AccelHandler gHandler { get; set; }

        private BackgroundWorker worker { get; set; }

        public GameView()
        {
            this.kHandler = new KeyHandler();
            this.gHandler = new AccelHandler();
            this.gHandler.A.ReadingChanged += A_ReadingChanged;

            this.InitializeComponent();

            // Set the key listener
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
            
            // set worker to work
            initWorker();
            //new Notification();
        }

        

        private void CurrentGame_GameEvent(object sender, EventArgs e)
        {
            endGame();
        }

        private void initWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }

        private async void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker workingGuy = (BackgroundWorker)sender;

            while (workingGuy.CancellationPending == false)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    NPC npc = CharacterFactory.Random(400, 600);
                    npc.timeToLive = CurrentGame.Difficulty.timeToLiveCharacters;
                    CurrentGame.CMan.Characters.Add(npc);
                });
                await Task.Delay(TimeSpan.FromMilliseconds(CurrentGame.RespawnSpeed));
            }

            e.Cancel = true;
            return;
        }

        private void A_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            if (CurrentGame != null)
            {
                CurrentGame.CMan.CurrentCharacter.move(gHandler.Direction);
                CurrentGame.runOnce();
            }
        }

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            kHandler.removeKey(args.KeyStatus.ScanCode);
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            uint code = args.KeyStatus.ScanCode;
            //Debug.WriteLine(code);
            switch (code)
            {
                case 14: worker.CancelAsync(); endGame(); break; // Go back (Backspace)

                default: kHandler.registerKey(code); CurrentGame.CMan.CurrentCharacter.move(kHandler.Direction); break;
            }

            CurrentGame.runOnce();
        }

        private async void endGame()
        {
            // Remove our listeners
            CurrentGame.GameEvent -= CurrentGame_GameEvent;
            gHandler.A.ReadingChanged -= A_ReadingChanged;
            worker.DoWork -= Worker_DoWork;

            CurrentGame.CMan.Close();

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                this.Frame.Navigate(typeof(HighScoreView), new HighScore(CurrentGame.CMan.CurrentCharacter.Name, CurrentGame.CMan.CurrentCharacter.Points, CurrentGame.Difficulty.difficulty));
               
            });
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            endGame();

        }

        private async void resetButton_Click(object sender, RoutedEventArgs e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                this.Frame.Navigate(typeof(GameView), null);
            });
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            this.CurrentGame = new BallCatcher(DifficultySettings.createByDifficulty(((Tuple<DifficultySettings.DIFFICULTY>)e.Parameter).Item1));
            CurrentGame.GameEvent += CurrentGame_GameEvent;

            if (ApplicationData.Current.LocalSettings.Values["username"] != null)
                CurrentGame.CMan.CurrentCharacter.Name = (string)ApplicationData.Current.LocalSettings.Values["username"];

            base.OnNavigatedTo(e);
        }

    }
}

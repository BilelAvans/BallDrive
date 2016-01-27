using System;
using Windows.Devices.Sensors;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using BallDrive.Data.Games;
using BallDrive.Data.Scores;
using BallDrive.Data.Controls;
using BallDrive.Data.Characters;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using BallDrive.Data.Notifications;
using BallDrive.Data.Characters.Enemies;
using BallDrive.Data.Characters.Items;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using System.Threading;

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
        private DispatcherTimer timer { get; set; }

        private bool isPaused = false;
        private DateTime lastPause;
        private DateTime lastSpecialSpawn;

        public GameView()
        {
            this.kHandler = new KeyHandler();
            this.gHandler = new AccelHandler();

            if (gHandler.A != null)
                this.gHandler.A.ReadingChanged += A_ReadingChanged;

            this.lastSpecialSpawn = DateTime.Now;

            this.InitializeComponent();

            // Set the key listener
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            // set worker to work
            initWorker();
            //new Notification();
        }

        

        private async void CurrentGame_GameEvent(object sender, EventArgs e)
        {
            endGame();

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                this.Frame.Navigate(typeof(HighScoreView), new HighScore(CurrentGame.CMan.CurrentCharacter.Name, CurrentGame.CMan.CurrentCharacter.Points, CurrentGame.Difficulty.difficulty));

            });
            
        }

        private void initWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;

            timer = new DispatcherTimer();
            timer.Interval += TimeSpan.FromMilliseconds(1000 / 10);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            CurrentGame.runOnce();
        }

        private async void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker workingGuy = (BackgroundWorker)sender;
            while (workingGuy.CancellationPending == false)
            {
                // We houden het maximum bescheiden om geen resource denial te veroorzaken op onze mobiele telefoon
                if (!isPaused && CurrentGame.CMan.Characters.Count < 30)
                {
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                    {
                        // Nieuwe vijand maken
                        NPC npc = CharacterFactory.Random(400, 600);
                        npc.timeToLive = CurrentGame.Difficulty.timeToLiveCharacters;
                        CurrentGame.CMan.Characters.Add(npc);
                        // Sneller nieuwe enemies aanmaken
                        CurrentGame.RespawnSpeed -= CurrentGame.Difficulty.reduceSpawnTimePerHit;
                        // Trager nieuwe bonussen neerzetten
                        CurrentGame.Difficulty.specialPowerSpawnTime += CurrentGame.Difficulty.reduceSpawnTimePerHit;
                        // Moeten we een bonus object neerzetten?
                        if (DateTime.Now - lastSpecialSpawn > CurrentGame.Difficulty.specialPowerSpawnTime)
                        {
                            // Item aanmaken
                            Item item = CharacterFactory.RandomItem(400, 600);
                            item.timeToLive = CurrentGame.Difficulty.timeToLiveCharacters;
                            CurrentGame.CMan.Characters.Add(item);
                            // Tijd registreren
                            lastSpecialSpawn = DateTime.Now;
                        }
                    });
                }
                await Task.Delay(CurrentGame.RespawnSpeed);
            }

            e.Cancel = true;
            return;
        }

        private void A_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            if (CurrentGame != null)
            {
                CurrentGame.CMan.CurrentCharacter.move(gHandler.Direction);
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
            
        }

        private void endGame()
        {
            // Remove our listeners
            CurrentGame.GameEvent -= CurrentGame_GameEvent;
           

            if (gHandler.A != null)
                gHandler.A.ReadingChanged -= A_ReadingChanged;

            worker.DoWork -= Worker_DoWork;
            worker.CancelAsync();

            timer.Stop();

            //CurrentGame.CMan.Close();

        }

        private async void CloseButton_Click(object sender, PointerRoutedEventArgs e)
        {
            endGame();

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                this.Frame.Navigate(typeof(HighScoreView), new HighScore(CurrentGame.CMan.CurrentCharacter.Name, CurrentGame.CMan.CurrentCharacter.Points, CurrentGame.Difficulty.difficulty));

            });
        }

        private async void resetButton_Click(object sender, PointerRoutedEventArgs e)
        {
            endGame();

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                this.Frame.Navigate(typeof(GameView), CurrentGame.Difficulty.difficulty);
            });
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            endGame();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
                CurrentGame = new BallCatcher(DifficultySettings.createByDifficulty((DifficultySettings.DIFFICULTY)e.Parameter));
            else
                CurrentGame = new BallCatcher(DifficultySettings.createByDifficulty(DifficultySettings.DIFFICULTY.EASY));

            CurrentGame.GameEvent += CurrentGame_GameEvent;

            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();

            timer.Start();

            if (ApplicationData.Current.LocalSettings.Values["username"] != null)
                CurrentGame.CMan.CurrentCharacter.Name = (string)ApplicationData.Current.LocalSettings.Values["username"];

            initWorker();

            base.OnNavigatedTo(e);
        }

        private void pauseButton_Click(object sender, PointerRoutedEventArgs e)
        {
            if (!isPaused)
            {
                isPaused = true;
                lastPause = DateTime.Now;
                CurrentGame.GameEvent -= CurrentGame_GameEvent;
                gHandler.A.ReadingChanged -= A_ReadingChanged;
                worker.CancelAsync();
                timer.Stop();
            }
            else {
                CurrentGame.Difficulty.gameTimeLength += DateTime.Now - lastPause;
                isPaused = false;
                CurrentGame.GameEvent += CurrentGame_GameEvent;
                gHandler.A.ReadingChanged += A_ReadingChanged;
                worker.RunWorkerAsync();
                timer.Start();
            }
        }

        private void infoButton_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GameInfoPage), "game");
        }

        private void enemyDiedAnimation_Completed(object sender, object e)
        {
            enemyDiedAnimation.Stop();
        }
    }
}

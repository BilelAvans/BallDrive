using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.ApplicationModel.Core;
using System.Linq;
using BallDrive.Data.Games;
using BallDrive.Data.Characters.Enemies;
using Windows.Storage;
using Windows.UI;
using BallDrive.Data.Characters.Animations;
using BallDrive.Data.Characters.Items;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;
using System.Diagnostics;
using System.Threading;

namespace BallDrive.Data.Characters
{
    public class CharacterManager
    {    

        public static ApplicationData AppData = ApplicationData.Current;
        public static ApplicationDataContainer AppDataContainer = AppData.LocalSettings;

        public ObservableCollection<Character> Characters { get; set; }

        private StoryCharacter currentCharacter;

        public StoryCharacter CurrentCharacter
        {
            get { return currentCharacter; }
            set { currentCharacter = value; }
        }

        public AnimationManager aniMan { get; set; }
        

        public ObservableCollection<BulletNPC> ShotsFired { get; set; } = new ObservableCollection<BulletNPC>();

        public DateTime LastBulletRelease { get; set; } = DateTime.Now;

        public TimeSpan BulletReleaseTimeSpan { get; set; } = TimeSpan.FromSeconds(1);
        public TimeSpan BulletReleaseMaxTimeSpan { get; set; } = TimeSpan.FromSeconds(10);

        public BackgroundWorker BulletReleaseThread = new BackgroundWorker();

        public ObservableCollection<Tuple<Position, int, int>> PointGains { get; set; } = new ObservableCollection<Tuple<Position, int, int>>();

        // Create with empty user set
        public CharacterManager()
        {
            // Main character/Player
            if (AppDataContainer.Values["prefcolorR"] != null)
                currentCharacter = new StoryCharacter(0, 0, Color.FromArgb(200, ((byte)AppDataContainer.Values["prefcolorR"]), (byte)AppDataContainer.Values["prefcolorG"], (byte)AppDataContainer.Values["prefcolorB"]));
            else
                currentCharacter = new StoryCharacter(0, 0);

            // Other characters/Enemies
            Characters = new ObservableCollection<Character>();
            aniMan = new AnimationManager();
            // Thread for shooting bullets
            BulletReleaseThread.DoWork += DoShootBullets;
            //addTestValues(6);
            //Characters.Add(new StarModeItem(100, 100));          

        }
        public void moveCurrentCharacter()
        {
            findCollision();
            removeLifeless();
            //aniMan.runAnimationsOnce();
        }

        public void findCollision()
        {
            try
            {
                // Wat hebben we geraakt?  
                List<Character> chas = Characters.Where(ch => ch.overlapsCircle(CurrentCharacter) == true || EnemiesHitByBullet(ch) == true).ToList();
                // Collisions verwijderen
                enemyShot(chas);
            }
            catch (InvalidOperationException e) { };
        }

        public void runLogic()
        {
            moveCurrentCharacter();
            moveBullets();
            iteratePointGains();
        }

        public void moveBullets()
        {
            if (ShotsFired.Count != 0)
            {
                ShotsFired.ToList().ForEach(shot =>
                {
                    shot.move();
                });
            }
        }

        public bool EnemiesHitByBullet(Character c){
            //List<Character> enemiesShot = Characters.Where(ch => ShotsFired.Exists(shot => shot.overlapsCircle(ch))).ToList();
            foreach (BulletNPC bullet in ShotsFired) {
                if (bullet.overlapsCircle(c))
                {
                    // Remove bullet when it hits a first object
                    ShotsFired.Remove(bullet);
                    // return the character
                    return true;
                }
            }

            return false;
        }

        public async void removeLifeless()
        {
            // Alle characters verwijderen die x periode op veld zijn
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                
                // Remove Non-decrement first
                Characters.Where(chara => chara.lifecycleEnded() == true).ToList()
                          .ForEach(ch2 => { ch2.removeAllHandlers(); Characters.Remove(ch2); });

                Characters.Where(character => character is NPC).Cast<NPC>().ToList()
                          .Where(chara => chara.lifecycleEnded() == true).ToList()
                          .ForEach(ch2 => { ch2.removeAllHandlers(); Characters.Remove(ch2); CurrentCharacter.Multi.Decrement(); });
            });
        }

        public async void iteratePointGains()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
            if (PointGains.Count != 0) {
                PointGains.ToList().ForEach(kvp => {
                    PointGains.Remove(kvp);
                    if (kvp.Item3 >= 15)
                    {
                        // Change position max 15 times then disappear.
                        // Do nufin, it's already removed. Just dont place it back again
                    }
                    else {
                        // Alter position
                        Position pos = kvp.Item1;
                        pos.Y -= 5;
                        // Alter iteration value (+1)
                        int k = kvp.Item3;
                        k++;
                        Tuple<Position, int, int> newKVP = new Tuple<Position, int, int> (pos, kvp.Item2, k);
                        PointGains.Add(newKVP);
                    }
                });
                }
            });


        }

        public async void runMoving()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                Characters.Where(ch1 => ch1 is MovingNPC).Cast<MovingNPC>().ToList().ForEach(ch2 => ch2.move(ch2.DirectionInDegrees));
            });
        }

        private void addTestValues(int amount)
        {
            // Test values
            Action action = () => Characters.Add(CharacterFactory.Random(400, 600));

            for (int counter = 0; counter < amount; counter++) {
                action();
            }
            
        }

        private void addToPointGains(Position p, int value)
        {
            PointGains.Add(new Tuple<Position, int, int>(p, value, 0));
        }
        

        private async void enemyShot(List<Character> enemies)
        {
            foreach (Character ch in enemies)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    // Wat hebben we geraakt en wat doen we ermee?
                    if (ch is BombNPC)
                    {
                        addToPointGains(ch.Position, -(CurrentCharacter.Points / 5));
                        CurrentCharacter.Multi.Clear();
                        CurrentCharacter.Points -= CurrentCharacter.Points / 5; // Lose 20% of Health
                    }
                    else if (ch is MovingNPC || ch is NPC)
                    {
                        int pointGain = CurrentCharacter.Multi.Increment();
                        addToPointGains(ch.Position, pointGain);
                        CurrentCharacter.Points += pointGain;
                    }
                    else if (ch is Item)
                    {
                        if (ch is StarModeItem)
                        {
                            CurrentCharacter.Multi.MPBonus = Multiplyer.multiplyerBonus.MULTIPLYER_X10_BONUS;
                            CurrentCharacter.Multi.MP = 10;
                        }
                        else if (ch is MultiplyerEnhancerItem)
                            CurrentCharacter.Multi.MPBonus = Multiplyer.multiplyerBonus.DOUBLE_POINTS;
                        else if (ch is ShooterItem)
                        {
                            BulletReleaseThread.RunWorkerAsync();

                        }
                        else if (ch is SpeedBoostItem)
                        {
                            CurrentCharacter.speedBoost();
                        }

                        // Run seperate worker to set effect for 5 minutes
                        BackgroundWorker worker = new BackgroundWorker();
                        worker.DoWork += Worker_DoWork;
                        worker.RunWorkerAsync();
                    }
                    Characters.Remove(ch);
                });
            }
        }

        private void Da_Completed(object sender, object e)
        {
            DoubleAnimation da = (DoubleAnimation)sender;
        }

        private async void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Color originalColor = CurrentCharacter.currentColor;
            // 5 seconden wachten
            DateTime now = DateTime.Now;
            while (DateTime.Now - now < TimeSpan.FromSeconds(5))
            {
                if (CurrentCharacter.Multi.MPBonus == Multiplyer.multiplyerBonus.MULTIPLYER_X10_BONUS)
                    CurrentCharacter.currentColor = Color.FromArgb(255, (byte)new Random().Next(255), (byte)new Random().Next(255), (byte)new Random().Next(255));
                await Task.Delay(250);
            }
            // Alles terugzetten
            CurrentCharacter.currentColor = originalColor;
            CurrentCharacter.Multi.MPBonus = Multiplyer.multiplyerBonus.NO_BONUS;
            CurrentCharacter.Multi.MP = 5;
        }

        private async void DoShootBullets(object sender, DoWorkEventArgs e)
        {
            int bulletsshot = 0;
            while (bulletsshot < 5)
            {
                // Release bullets
                for (int ang = 0; ang < 360; ang += 60)
                {
                    Debug.WriteLine("Shooting bullet towards angle {0}", ang);
                    double spawnX, spawnY;
                    spawnX = CurrentCharacter.Position.X += 5 * Math.Cos(ang);
                    spawnY = CurrentCharacter.Position.Y -= 5 * Math.Sin(ang);
                    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                    {
                        ShotsFired.Add(new BulletNPC(CurrentCharacter.Position, ang, (int)spawnX, (int)spawnY));

                    });
                    
                }

                LastBulletRelease = DateTime.Now;
                bulletsshot++;
                await Task.Delay((int)BulletReleaseTimeSpan.TotalMilliseconds);
            }
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                ShotsFired.Clear();
            });
            
        }

        public async void Close()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                Characters.Clear();
            });
        }
        
    }
}

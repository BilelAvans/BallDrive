using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Windows.ApplicationModel.Core;
using System.Linq;
using BallDrive.Data.Games;
using System.Diagnostics;
using BallDrive.Data.Characters.Enemies;
using Windows.Storage;
using Windows.UI;
using BallDrive.Data.Characters.Animations;
using BallDrive.Data.Characters.Items;
using System.Threading.Tasks;

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
            //addTestValues(6);
            //Characters.Add(new StarModeItem(100, 100));          

        }

        public void moveCurrentCharacter()
        {
            runMoving();
            findCollision();
            removeLifeless();
            aniMan.runAnimationsOnce();
        }

        public void findCollision()
        {
            try
            {
                List<Character> chas = Characters.Where(ch => ch.overlapsCircle(CurrentCharacter) == true).ToList();
                    
                // Collisions verwijderen
                enemyShot(chas);
            }
            catch (InvalidOperationException e) { };
        }

        public async void removeLifeless()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                Characters.Where(character => character is NPC).Cast<NPC>().ToList()
                          .Where(chara => chara.lifecycleEnded() == true).ToList()
                          .ForEach(ch2 => { ch2.removeAllHandlers(); Characters.Remove(ch2); CurrentCharacter.Multi.Decrement(); });

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
        

        private async void enemyShot(List<Character> enemies)
        {
            foreach (Character ch in enemies)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    if (ch is BombNPC)
                    {
                        CurrentCharacter.Multi.Clear();
                        CurrentCharacter.Points -= CurrentCharacter.Points / 5; // Lose 20% of Health
                    }
                    else if (ch is MovingNPC || ch is NPC)
                        CurrentCharacter.Points += CurrentCharacter.Multi.Increment();
                    else if (ch is Item)
                    {
                        if (ch is StarModeItem)
                        {
                            CurrentCharacter.Multi.MPBonus = Multiplyer.multiplyerBonus.MULTIPLYER_X10_BONUS;
                            CurrentCharacter.Multi.MP = 10;
                        }
                        else if (ch is MultiplyerEnhancerItem)
                            CurrentCharacter.Multi.MPBonus = Multiplyer.multiplyerBonus.DOUBLE_POINTS;

                        BackgroundWorker worker = new BackgroundWorker();
                        worker.DoWork += Worker_DoWork;
                        worker.RunWorkerAsync();
                    }
                    
                    Characters.Remove(ch);
                    ch.removeAllHandlers();
                });
            }
        }

        private async void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // 5 seconden wachten
            await Task.Delay(TimeSpan.FromSeconds(5));
            // Alles terugzetten
            CurrentCharacter.Multi.MPBonus = Multiplyer.multiplyerBonus.NO_BONUS;
            CurrentCharacter.Multi.MP = 5;
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

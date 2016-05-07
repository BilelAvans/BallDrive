using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallDrive.Data.Characters;
using Windows.Foundation;
using System.Diagnostics;
using System.ComponentModel;
using Windows.ApplicationModel.Core;
using BallDrive.Data.Notifications;
using BallDrive.Data.Controls;
using BallDrive.Data.Characters.Enemies;

namespace BallDrive.Data.Games
{
    public abstract class Game: INotifyPropertyChanged
    {

        public event EventHandler GameEvent;

        public event PropertyChangedEventHandler PropertyChanged;

        protected DateTime startTime;

        public TimeSpan TimeLeft { get { return (startTime + Difficulty.gameTimeLength) - DateTime.Now; } }
        // History of point gains
        

        public DifficultySettings Difficulty;
        // Start repawn speed at 1 second
        public TimeSpan RespawnSpeed { get; set; } 

        public CharacterManager CMan { get; set; }

        public Game(DifficultySettings diffSettings)
        {
            CMan = new CharacterManager();
            this.Difficulty = diffSettings;
            this.startTime = DateTime.Now;
            this.RespawnSpeed = diffSettings.initRespawnTime;
        }

        public void runOnce()
        {
            
            CMan.runLogic();
            hasEnded();
        }
        
        public void hasEnded()
        {
            Changed("TimeLeft");
            if (GameEvent != null)
            {
                if (TimeLeft < TimeSpan.FromSeconds(0))
                    GameEvent(this, new EventArgs());
            }
            
        }

        public async void Changed(string propertyname)
        {
            if (PropertyChanged != null)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                });
            }
        }

        ~Game() {

            removeAllHandlers();
        }

        private void removeAllHandlers()
        {
            if (PropertyChanged != null)
            {
                // Alle invokers afsluiten
                PropertyChanged.GetInvocationList().ToList().ForEach(del => PropertyChanged -= (PropertyChangedEventHandler)del);
                PropertyChanged = null;
            }
        }
    }
}

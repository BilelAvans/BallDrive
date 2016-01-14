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

namespace BallDrive.Data.Games
{
    public abstract class Game: INotifyPropertyChanged
    {

        public event EventHandler GameEvent;

        public event PropertyChangedEventHandler PropertyChanged;

        protected DateTime startTime;

        public TimeSpan TimeLeft { get { return (startTime + Difficulty.gameTimeLength) - DateTime.Now; } }


        public DifficultySettings Difficulty;

        public double RespawnSpeed { get; set; } = 1000;

        public CharacterManager CMan { get; set; }

        public Game(DifficultySettings diffSettings)
        {
            CMan = new CharacterManager();
            this.Difficulty = diffSettings;
            this.startTime = DateTime.Now;
        }

        public void runOnce()
        {
            CMan.moveCurrentCharacter();
            hasEnded();
        }
        
        public void hasEnded()
        {
            Changed("TimeLeft");
            RespawnSpeed -= 0.001;
            if (TimeLeft < TimeSpan.FromSeconds(0))
                GameEvent(this, new EventArgs());
            
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
    }
}

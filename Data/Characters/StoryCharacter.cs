using BallDrive.Data.Characters.Enemies;
using BallDrive.Data.Controls;
using BallDrive.Data.Games;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI;

namespace BallDrive.Data.Characters
{
    public class StoryCharacter : Character, INotifyPropertyChanged
    {

        private int points = 0;
        public int Points { get { return points; } set { points = value; Changed("Points"); } }

        public ObservableCollection<Position> LastPositions { get; set; } = new ObservableCollection<Position>();

        public const int ADD_STEP_EVERY_X_MOVES = 4;
        public int stepCounter = 0;

        private Multiplyer multi;
        public Multiplyer Multi { get { return multi; } set { this.multi = value; Changed("Multi"); Changed("Speed"); } }

        public new int Speed { get { return (int)multi.MP * 3; } }

        public StoryCharacter(int x, int y): this(x, y, Colors.Black)
        {
        }

        public StoryCharacter(int x, int y, Color color) : base(x, y, 10, 50, color)
        {
            multi = new Multiplyer(DifficultySettings.DIFFICULTY.NORMAL);
            
        }

        public new void move(ControlHandler.Directions dir)
        {
            base.move(dir);
            stepCounter++;

            if (stepCounter % ADD_STEP_EVERY_X_MOVES == 0)
            {
                addToLastPositions(new Enemies.Position(Position.X, Position.Y));
                stepCounter = 0;
            }
        } 

        public void addPoints(int amount)
        {
            points += amount;
        }

        public async void addToLastPositions(Position p)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
            {
                // Remember 3 last positions and throw away first added item 
                if (LastPositions.Count >= 4)
                    LastPositions.RemoveAt(0);
                
                // Add the next position
                LastPositions.Add(p);

                // Set size relative to order moved in
                for (int counter = 1; counter < LastPositions.Count; counter++)
                    LastPositions[counter].Size = 25 - (5 * counter);
                
                Changed("LastPositions");
            });
        }
        /*
        public new bool outOfBounds(int boundX, int boundY)
        {
            if (base.outOfBounds())
            {
                
            }
        }
        */
    }
}

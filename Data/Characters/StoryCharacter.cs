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
    public class StoryCharacter : NPC, INotifyPropertyChanged
    {

        private int points = 0;
        public int Points { get { return points; } set { points = value; Changed("Points"); } }

        public ObservableCollection<Position> LastPositions { get; set; } = new ObservableCollection<Position>();

        public const int ADD_STEP_EVERY_X_MOVES = 4;
        public int stepCounter = 0;

        private Multiplyer multi;
        public Multiplyer Multi { get { return multi; } set { this.multi = value; Changed("Multi"); Changed("Speed"); } }

        public new int Speed { get { return ((int)multi.MP + extraSpeed) / 3 + 1; } }

        public int extraSpeed = 0;

        public string Name { get; set; } = "Bob";

        public StoryCharacter(int x, int y): this(x, y, Colors.Black)
        {
        }

        public StoryCharacter(int x, int y, Color color) : base(x, y, 10, 50, color)
        {
            multi = new Multiplyer(DifficultySettings.DIFFICULTY.NORMAL);
            
        }

        public new void move(ControlHandler.Directions dir)
        {
            switch (dir)
            {
                case KeyHandler.Directions.NORTH: move(0, -this.Speed); break; // Go up
                case KeyHandler.Directions.NORTH_WEST: move(-this.Speed, -this.Speed); break;
                case KeyHandler.Directions.WEST: move(this.Speed, 0); break; // Go Left
                case KeyHandler.Directions.NORTH_EAST: move(this.Speed, -this.Speed); break;
                case KeyHandler.Directions.EAST: move(this.Speed, 0); break; // Go Right
                case KeyHandler.Directions.SOUTH_EAST: move(this.Speed, this.Speed); break;
                case KeyHandler.Directions.SOUTH: move(0, this.Speed); break; // Go Down
                case KeyHandler.Directions.SOUTH_WEST: move(-this.Speed, this.Speed); break;
            }

            stepCounter++;

            if (stepCounter % ADD_STEP_EVERY_X_MOVES == 0)
            {
                addToLastPositions(new Enemies.Position(Position.X, Position.Y));
                stepCounter = 0;
            }

            // Reflect to other side?
            if (Position.X < 0)
                Position.X = 400;
            if (Position.Y < 0)
                Position.Y = 600;
            if (Position.X > 400)
                Position.X = 0;
            if (Position.Y > 600)
                Position.Y = 0;
        } 

        public void addPoints(int amount)
        {
            points += amount;
            Changed("Speed");
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

        public void speedBoost()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Do_SpeedBoost;
            worker.RunWorkerAsync();
        }

        public async void Do_SpeedBoost(object sender, DoWorkEventArgs args) {
            for (int speedIncreaseTimer = 1; speedIncreaseTimer < 3; speedIncreaseTimer++)
            {
                extraSpeed = speedIncreaseTimer;
                Changed("Speed");
                Debug.WriteLine("Changed speed to {0}", this.Speed);
                // Wait second after increase
                await Task.Delay(2000);
            }

            extraSpeed = 0;

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

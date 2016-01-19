using BallDrive.Data.Characters.Enemies;
using BallDrive.Data.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace BallDrive.Data.Characters
{
    // Use this interface for every character that will be moving inside our game frame
    public abstract class Character : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        // X-Y representatie van de positie (In XAML omwerken met een Converter; Position<Key>, Position<Value> => Margin(....)
        protected Position position;
        public Position Position { get { return position; } set { position = value; Changed("Position"); } }

        private Color color = Colors.Black;
        public Color currentColor { get { return color; } set { color = value; Changed("currentColor"); Changed("color"); } }

        public Brush brush { get { return new SolidColorBrush(color); } }

        // Might set an image for the character
        private Image image { get; set; }
        public TimeSpan timeToLive { get; set; }
        // Size of our shape
        public int Size { get; set; }

        public const int maxHealth = 100;

        public int Speed { get; set; }

        // Constructor for NPC's
        public Character(int x, int y, int speed, int size, Color color)
        {
            this.Position = new Position(x, y);
            this.Speed = speed;
            this.Size = size;
            this.currentColor = color;
        }

        // Constructor for Ítems
        public Character(int x, int y, int size)
        {
            this.Position = new Position(x, y);
            this.Size = size;
        }

        public void move(int x, int y)
        {
            Position.X = Position.X + x * this.Speed;
            Position.Y = Position.Y + y * this.Speed;
        }



        public void move(ControlHandler.Directions direction)
        {

            switch (direction)
            {
                case KeyHandler.Directions.NORTH: move(0, -1); break; // Go up
                case KeyHandler.Directions.NORTH_WEST: move(-1, -1); break;
                case KeyHandler.Directions.WEST: move(-1, 0); break; // Go Left
                case KeyHandler.Directions.NORTH_EAST: move(1, -1); break;
                case KeyHandler.Directions.EAST: move(1, 0); break; // Go Right
                case KeyHandler.Directions.SOUTH_EAST: move(1, 1); break;
                case KeyHandler.Directions.SOUTH: move(0, 1); break; // Go Down
                case KeyHandler.Directions.SOUTH_WEST: move(-1, 1); break;
            }

        }

        public void move(int angle)
        {
            double x = (double)(Position.X + Speed * Math.Cos(angle));
            double y = (double)(Position.Y + Speed * Math.Sin(angle));

            Position = new Position(x, y);
        }


        // Rects
        public bool collidesWith(Character c)
        {
            if (this.Position.X < c.Position.X + c.Size &&
                    this.Position.X + this.Size > c.Position.X &&
                    this.Position.Y < c.Position.Y + c.Size &&
                    this.Size + this.Position.Y > c.Position.Y
            )
                return true;

            return false;
        }

        public List<Character> collidingWith(List<Character> currentCharacters)
        {
            return currentCharacters.Where(ch => ch.overlapsCircle(this)).ToList();
        }

        public async void Changed(string propertyName)
        {
            if (PropertyChanged != null)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    try
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                    catch (NullReferenceException ex)
                    {
                        Debug.WriteLine("is null {0}", ex.Source.GetType().ToString());
                    }
                });
            }
        }

        public Position origin()
        {
            return new Position(this.Position.X + this.Size / 2, this.Position.Y + this.Size / 2);
        }

        public bool outOfBounds(int width, int height)
        {
            if (this.Position.X < (0) || this.Position.X > (width) ||
                this.Position.Y < (0) || this.Position.Y > (height))
            {
                return true;
            }

            return false;

        }

        public void removeAllHandlers()
        {
            if (PropertyChanged != null)
            {
                foreach (Delegate del in PropertyChanged.GetInvocationList())
                {
                    PropertyChanged -= (PropertyChangedEventHandler)del;
                    PropertyChanged = null;
                }
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BallDrive.Data.Characters.Enemies
{
    public class BulletNPC: NPC
    {

        // Original firing position
        Position basePosition;
        // Movement angle
        private double angle;

        // Our spikedNPC image
        public BitmapImage image;
        public new Brush brush { get; private set; }

        public BulletNPC(Position basePosition, double angle, int x, int y): base(x, y)
        {
            this.basePosition = basePosition;
            this.angle = angle;

            this.image = new BitmapImage();
            this.brush = setBrush();
            this.Size = 20;
        }

        private ImageBrush setBrush()
        {
            image = new BitmapImage(new Uri("ms-appx:///Assets/rocket.png"));
            ImageBrush imageb = new ImageBrush();
            imageb.ImageSource = image;
            return imageb;
        }

        public void move()
        {
            Position.X += 6 * Math.Cos(angle);
            Position.Y -= 6 * Math.Sin(angle);
        }


    }
}

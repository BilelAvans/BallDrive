using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BallDrive.Data.Characters.Enemies
{
    public class MultiplyerBonusNPC: NPC
    {
        public BitmapImage image;

        public new Brush brush { get; private set; }

        public MultiplyerBonusNPC(int x, int y): base(x, y)
        {
            this.image = new BitmapImage();
            this.brush = setBrush();
            this.Size = 40;
        }

        private ImageBrush setBrush()
        {
            image = new BitmapImage(new Uri("ms-appx:///Assets/bomb-30x31.png"));
            ImageBrush imageb = new ImageBrush();
            imageb.ImageSource = image;
            return imageb;
        }
    }
}

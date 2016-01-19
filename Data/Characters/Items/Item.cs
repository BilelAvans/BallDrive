using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BallDrive.Data.Characters.Items
{
    public class Item: Character
    {

        // Our spikedNPC image
        public BitmapImage image;

        public new Brush brush { get; private set; }

        public Item(int x, int y, string imagePath): base(x, y, 30)
        {
            this.image = new BitmapImage();
            this.brush = setBrush("ms-appx:///"+ imagePath);
            this.Size = 40;
        }

        private ImageBrush setBrush(string uriPath)
        {
            image = new BitmapImage(new Uri(uriPath));
            ImageBrush imageb = new ImageBrush();
            imageb.ImageSource = image;
            return imageb;
        }
    }
}

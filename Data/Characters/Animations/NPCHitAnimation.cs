using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace BallDrive.Data.Characters.Animations
{
    class NPCHitAnimation : IAnimation
    {
        public Shape Animation { get; set; }

        public int totSteps = 0;
        public const int MAX_STEPS = 25;

        public NPCHitAnimation()
        {
            Animation = new Ellipse();
            Animation.Width = 25;
            Animation.Height = 25;
            Animation.Fill = new SolidColorBrush(Colors.Cyan);
        }

        public void reformOnce()
        {
            Animation.Width++;
            Animation.Height++;
            Animation.Opacity--;
            totSteps++;
        }


        public bool isDone()
        {
            if (totSteps >= MAX_STEPS)
                return true;

            return false;
        }
    }
}

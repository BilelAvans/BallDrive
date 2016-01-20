using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Shapes;

namespace BallDrive.Data.Characters.Animations
{
    interface IAnimation
    {
        // Animation in form of a shape
        List<Shape> Animations { get; set; }
        // Reshape the animation to next animation state
        void reformOnce();
        // Is it done?
        bool isDone();
    }
}

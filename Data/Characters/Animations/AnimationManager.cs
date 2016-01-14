using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallDrive.Data.Characters.Animations
{
    public class AnimationManager 
    {
        
        ObservableCollection<IAnimation> Animations { get; set; }

        public AnimationManager()
        {
            Animations = new ObservableCollection<IAnimation>();
        }

        public void runAnimationsOnce()
        {
            Animations.ToList().ForEach(ani =>
            {
                ani.reformOnce();
                if (ani.isDone())
                {
                    Animations.Remove(ani);
                }
            });
        }

    }
}

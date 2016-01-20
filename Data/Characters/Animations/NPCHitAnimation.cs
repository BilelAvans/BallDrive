using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace BallDrive.Data.Characters.Animations
{
    public class NPCHitAnimation : IAnimation, INotifyPropertyChanged
    {
        public List<Shape> Animations { get; set; }

        public int totSteps = 0;
        public const int MAX_STEPS = 25;

        public event PropertyChangedEventHandler PropertyChanged;

        public NPCHitAnimation(int hitatX, int hitatY)
        {
            Animations = new List<Shape>();
            Ellipse el = new Ellipse();
            el.Width = hitatX;
            el.Height = hitatY;
            Animations.Add(el);
        }

        public void reformOnce()
        {
            if (totSteps == 0) {
                Ellipse el = (Ellipse)Animations[0];
                for (int counter = 0; counter < 6; counter++)
                {
                    Ellipse ell = new Ellipse();
                    ell.Width = el.Width + 1 * Math.Cos((360 / 6) * counter);
                    ell.Height = el.Height + 1 * Math.Sin((360 / 6) * counter);
                    Animations.Add(ell);
                }
                Animations.Remove(el);
                
            }
            else if (totSteps < 50) {
                for (int counter = 0; counter < 6; counter++)
                {
                    Ellipse ell = (Ellipse)Animations[counter];
                    ell.Width = ell.Width + 1 * Math.Cos((360 / 6) * counter);
                    ell.Height = ell.Height + 1 * Math.Sin((360 / 6) * counter);
                    ell.Opacity -= 0.01;
                }
            }
        }

        public async void Changed(string propertyName)
        {
            if (PropertyChanged != null)
            {
                await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                });
            }
        }


        public bool isDone()
        {
            if (totSteps >= MAX_STEPS)
                return true;

            return false;
        }

        ~NPCHitAnimation()
        {
            PropertyChanged.GetInvocationList().ToList().ForEach(del =>
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged -= (PropertyChangedEventHandler)del;
                }
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace BallDrive.Data.Characters.Enemies
{
    public class Position: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private double x = 0;
        public double X { get { return x; } set { x = value; Changed("X"); } }
        private double y = 0;
        public double Y { get { return y; } set { y = value; Changed("Y"); } }

        public int Size { get; set; }

        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public async void Changed(string propertyName)
        {
            if (PropertyChanged != null)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace BallDrive.Data.Characters
{
    public class PointsToColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((int)value < 0)
                return new SolidColorBrush(Colors.Red);
            if ((int)value > 0)
                return new SolidColorBrush(Colors.Green);

            return new SolidColorBrush(Colors.Yellow);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            
            SolidColorBrush received = (SolidColorBrush)value;
            return received.Color;
            
        }
    }
}

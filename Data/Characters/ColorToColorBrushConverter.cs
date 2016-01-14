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
    public class ColorToColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (Brush)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            SolidColorBrush received = (SolidColorBrush)value;
            return received.Color;
        }
    }
}

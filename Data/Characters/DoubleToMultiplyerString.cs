using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BallDrive.Data.Characters
{
    class DoubleToMultiplyerString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string tempString = "";

            tempString = "(" + (double)value + "x)";
            return tempString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

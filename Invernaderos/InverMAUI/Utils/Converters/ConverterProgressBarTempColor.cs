using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverMAUI.Utils.Converters
{
    public class ConverterProgressBarTempColor : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            string color ="";

            if (value != null)
            {
                double valorColor = (double)value;

                if (valorColor > 35)
                {
                    color = "Orange";
                }
                else if (valorColor <= 20)
                {
                    color = "Blue";
                }
                else if (valorColor > 40)
                {
                    color = "Red";
                }
                else
                {
                    color = "Green";
                }
            }    
            return color;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

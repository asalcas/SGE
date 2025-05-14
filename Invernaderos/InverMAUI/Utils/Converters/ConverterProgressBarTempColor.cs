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
        /// <summary>
        /// Función que se encarga de pasar una temperatura entre 10 y 55 cº para determinar el color a usar
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
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

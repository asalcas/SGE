using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbzMAUIQuizz.Models.Converters
{
    public class ConverterColorTiempo : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Color colorDelTiempo = Color.FromArgb("#ffe4d6");
            int tiempoActual;
            if(value != null)
            {
                tiempoActual = (int)value;

                if (tiempoActual >= 0 && tiempoActual <= 2)
                {
                    colorDelTiempo = Color.FromArgb("#e06159");

                }else if (tiempoActual > 2 && tiempoActual <= 4)
                {
                    colorDelTiempo = Color.FromArgb("#dfb969");
                }
                else
                {
                    colorDelTiempo = Color.FromArgb("#ffffff");
                }
            }

            return colorDelTiempo;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

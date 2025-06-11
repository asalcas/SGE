using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbzMAUIQuizz.Models.Converters
{
    public class ConverterColorNombre : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Color colorDelTexto = Color.FromArgb("#d3d3d3");
            Boolean esCorrecto;

            if (value != null)
            {
                esCorrecto = (Boolean)value;
                if (esCorrecto)
                {
                    colorDelTexto = Color.FromArgb("#016000");
                }
                else
                {
                    colorDelTexto = Color.FromArgb("#c51d40");
                }
            }
            
                return colorDelTexto;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

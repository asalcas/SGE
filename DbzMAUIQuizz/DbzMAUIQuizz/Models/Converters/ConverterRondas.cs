using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbzMAUIQuizz.Models.Converters
{
    public class ConverterRondas : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            int aConvertir = 0;

            if ( value != null)
            {
                aConvertir = (int)value;
                aConvertir++;
                if(aConvertir == 21)
                {
                    aConvertir--;
                }
            }
            return aConvertir;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

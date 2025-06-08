using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbzMAUIQuizz.Models.Converters
{
    public class ConverterNombres : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            String aConvertir = "";
            String aRetornar = "";
            if(value != null)
            {
                aConvertir = (String)value;
                aRetornar = aConvertir.Length > 3 ? aConvertir.Substring(0, 3) : aConvertir; // Si el tamaño del nombre es mayor de 3, hacemos un substring de 3 
            }
            return aRetornar;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

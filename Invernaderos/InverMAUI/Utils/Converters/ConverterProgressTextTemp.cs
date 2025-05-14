using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverMAUI.Utils.Converters
{
    public class ConverterProgressTextTemp : IValueConverter
    {
        /// <summary>
        /// Función que se encarga de determinar si el valor que queremos convertir es nulo o no para mandar un value con un StringFormat con el Cº de la temperatura o el ?

        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            String mensaje = "";

            mensaje = value != null ? $"{value} Cº" : "?";
            
            return mensaje;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

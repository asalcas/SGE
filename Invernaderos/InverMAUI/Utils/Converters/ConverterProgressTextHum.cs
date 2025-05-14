using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverMAUI.Utils.Converters
{
    public class ConverterProgressTextHum : IValueConverter
    {
        /// <summary>
        /// Función que se encarga de determinar si el valor que queremos convertir es nulo o no para mandar un value con un StringFormat con el % de la humedad o el ?
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            String mensaje = "";
            Debug.WriteLine($"El valor de value aquí es {value}");
            mensaje = value != null ? $"{value} %" : "?";

            return mensaje;

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

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

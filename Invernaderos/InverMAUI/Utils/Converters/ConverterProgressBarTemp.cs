using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverMAUI.Utils.Converters
{
    public class ConverterProgressBarTemp : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double? temperatura = 0;
            double minTemp = 10.0;
            double maxTemp = 55.0;

            //Debug.WriteLine($"Ahora mismo value es {value}");

            temperatura = (double?)value; // Error con (double) como puede ser nulable tiene que ser asi (double?) 

            if (temperatura != null)
            {
                ;
                if (temperatura >= minTemp && temperatura <= maxTemp)
                {// si es mayor de los topes hacemos la operación
                    temperatura = (temperatura - minTemp) / (maxTemp - minTemp);
                }
                else
                {
                    // Sino , si es menor que min temp lo asignamos a 0, por el contrario 1
                    temperatura = temperatura < minTemp ? 0 : 1;
                }

            }
            


                return temperatura;


        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

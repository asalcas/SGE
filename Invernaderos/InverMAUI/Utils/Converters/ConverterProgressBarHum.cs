using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverMAUI.Utils.Converters
{
    public class ConverterProgressBarHum : IValueConverter
    {
        /// <summary>
        /// Función que recive y convierte un valor entre 0 y 99 y devuelve un float 0-1
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) // ------------------------------- HACER QUE FUNCIONEN LOS CONVERTERS
        {
            double resultado = 0;
            double numeroOperar = 0;
            //Debug.WriteLine("El valor que tiene value es de: " + value);
            if (value != null)
            {

                numeroOperar = (double)value;
                resultado = numeroOperar / 100;
                
            }

            return resultado;


        }
        /// <summary>
        /// Retornamos el mismo valor por que no necesitamos ninguna conversion de vuelta
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

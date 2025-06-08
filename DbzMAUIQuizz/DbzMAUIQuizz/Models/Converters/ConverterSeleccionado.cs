using DbzMAUIQuizz.VM;
using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbzMAUIQuizz.Models.Converters
{
    public class ConverterSeleccionado : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Color color = Color.FromArgb("#c4542d");

            if (value != null)
            {
                if (value is Boolean esCorrecto)
                {
                    if (esCorrecto)
                    {
                        color = Color.FromArgb("#98c379");
                    }
                    
                    
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

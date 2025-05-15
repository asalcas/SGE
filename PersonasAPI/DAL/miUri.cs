using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class miUri
    {
        /// <summary>
        /// Función que llamada desde la Dal que lo que hace es retornar un String con lo que es nuestra cadena para realizar la conexion con la API
        /// </summary>
        /// <returns> String uriBase </returns>
        public static String getUriBase()
        {
            String uriBase = "personasapi-hwfxccdpewgectck.spaincentral-01.azurewebsites.net/api/";

            return uriBase;
        }

    }
}

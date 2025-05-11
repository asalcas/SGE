using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;

namespace BL
{
    public class ListadoClsTemperaturaBL
    {
        /// <summary>
        /// Función que llama a la DAL para obtener un objeto tipo 'ClsTemperatura' según su 'id' y 'fecha'
        /// PRE: 'id' o 'fecha' nunca puede ser NULL
        /// POST: Retorna un objeto tipo ClsTemperatura entero o Vacío
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static ClsTemperatura temperaturaPorInvernaderoYFecha(int id, DateTime fecha)
        {
            return DAL.ListadosClsTemperaturasDAL.obtenerTemperaturasPorInvernaderoYFecha(id, fecha);
    
        }

        /// <summary>
        /// Función que llama a la DAL para comprobar si la fecha existe o no
        /// PRE: 'fecha' no puede ser NULL
        /// POST: Retorna un BOOLEAN
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static Boolean comprobacionFecha(DateTime fecha)
        {
            return DAL.ListadosClsTemperaturasDAL.comprobarFecha(fecha);
        }

        
    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;

namespace BL
{
    public class ListadoClsTemperaturaConInvernaderoYFecha
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


        // DEBERIA DESPUES POR AQUI, hacer un metodo que compruebe si existe o no la temperatura y si el ClsTemperatura está vacío entonces que 
        // Devuelva un BOOLEAN que sea False, para mas adelante en la ui, mostrar Mensajes
    }



}

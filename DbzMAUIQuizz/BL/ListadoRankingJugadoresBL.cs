using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ListadoRankingJugadoresBL
    {
        /// <summary>
        /// Función que aplicara las reglas de negocio a una llamada desde la DAL a la API que hara un GET de toda la lista de Jugadores pero ORDENADOS POR PUNTUACIÓN
        /// PRE: None
        /// POST: Devuelve un listado de tipo 'ClsJugador'
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsJugador>> obtenerListadoOrdenadoJugadoresBL()
        {
            return await DAL.ListadoRankingJugadoresDAL.obtenerListadoCompletoJugadoresOrdenados(); ;
        }
    }
}

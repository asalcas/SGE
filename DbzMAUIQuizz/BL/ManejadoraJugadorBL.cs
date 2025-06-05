using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ManejadoraJugadorBL
    {

        /// <summary>
        /// Función que aplica las reglas de Negocio a una llamada a la API a través de la DAL, que realizará un POST de un Jugador con su puntuación.
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> insertarPuntuacionJugadorBL(ClsJugador jugador)
        {
            return await DAL.ManejadoraJugadorDAL.insertarPuntuacionJugadorDAL(jugador);
        }
    }
}

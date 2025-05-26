using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ManjeadoraClsJugador
    {
        /// <summary>
        /// Funcion que sirve de puente para aplicar las reglas de negocio a un insert SQL antes de llegar a la DAL.
        /// </summary>
        /// <param name="nombreJugador"></param>
        /// <param name="puntuacionJugador"></param>
        /// <returns></returns>
        public static int insertarJugadorBL(String nombreJugador, int puntuacionJugador)
        {
            return DAL.ManejadoraClsJugador.insertarJugadorDAL(nombreJugador, puntuacionJugador);
        }
    }
}

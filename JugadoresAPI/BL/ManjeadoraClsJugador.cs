using ENT;
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
        public static int insertarJugadorBL(ClsJugador jugador)
        {
            return DAL.ManejadoraClsJugador.insertarJugadorDAL(jugador);
        }

        /// <summary>
        /// Funcion que sirve de puente para aplicar las reglas de negocio a un Update SQL antes de llegar a la DAL.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public static int updateJugadorBL(ClsJugador jugador)
        {
            return DAL.ManejadoraClsJugador.updateUsuario(jugador);
        }

        /// <summary>
        /// Funcion que sirve de puente para aplicar las reglas de negocio a un Delete SQL antes de llegar a la DAL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int borrarJugadorBL(int id)
        {
            return DAL.ManejadoraClsJugador.deletePersona(id);
        }
    }
}

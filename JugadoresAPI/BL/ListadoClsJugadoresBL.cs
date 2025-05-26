using ENT;

namespace BL
{
    public class ListadoClsJugadoresBL
    {
        /// <summary>
        /// Funcion que sirve de puente para aplicar las reglas de negocio a una consulta SQL en la DAL.
        /// </summary>
        /// <returns></returns>
        public static List<ClsJugador> obtenerTodosLosJugadoresBL()
        {
            return DAL.ListadoClsJugadores.obtenerTodosLosJugadoresDAL();
        }

        /// <summary>
        /// Funcion que sirve de puente para aplicar las reglas de negocio a una consulta SQL en la DAL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ClsJugador obtenerJugadorPorIDBL(int id)
        {
            return DAL.ListadoClsJugadores.obtenerJugadorPorIDDAL(id);
        }

    }
}

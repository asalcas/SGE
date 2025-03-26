using DAL;
using ENT;

namespace BL
{
    public class ListadoPersonasBL
    {
        private static List<ClsPersona> listadoCompletoPersonasBL = ListadoPersonasDAL.ObtenerListadoCompletoDAL();

        /// <summary>
        /// Función que retorna 'listadoCompletoPersonasBL' (copia de la DAL, pero aplicando sus Logica de negocio)
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns>listadoCompletoPersonasBL</returns>
        public static List<ClsPersona> ObtenerlistadoCompletoPersonasBL()
        {
            return listadoCompletoPersonasBL;
        }
    }


}

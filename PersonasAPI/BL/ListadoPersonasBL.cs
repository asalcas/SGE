using System.Collections.ObjectModel;
using DAL;
using ENT;

namespace BL
{
    public class ListadoPersonasBL
    {
        /// <summary>
        /// Función que llamara llama a 'getListadoPersonasCompletoDAL' para traer una lista de Objetos Tipo 'ClsPersona'
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsPersona>> obtenerListaCompletaPersonasBL()
        {

            return await ListadoPersonasDAL.getListadoPersonasCompletoDAL();
        }
    }
}

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
        public static async Task<ObservableCollection<ClsPersona>> obtenerListaCompletaPersonasBL()
        {
            List<ClsPersona> listaPersonas = await ListadoPersonasDAL.getListadoPersonasCompletoDAL();
            return new ObservableCollection<ClsPersona>(listaPersonas);
        }
    }
}

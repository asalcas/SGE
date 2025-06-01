using DTO;

namespace BL
{
    public class ListadoPersonajesBL
    {
        /// <summary>
        /// Función que aplicaría reglas de negocio a una obtención de datos en la DAL
        /// PRE: 
        /// POST: 
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ClsPersonajeDBZ>> getAllPersonajesBL()
        {
            return await DAL.ListadoPersonajesDAL.getAllPersonajesDAL();
        }
    }
}

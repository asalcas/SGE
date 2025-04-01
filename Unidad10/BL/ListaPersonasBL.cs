using DAL;
using ENT;

namespace BL
{
    public class ListaPersonasBL
    {
        public static List<ClsPersona> ObtenerListaPersonasCompletaBL()
        {
            return ListaPersonasDAL.ObtenerListadoCompletoPersonasDAL();
        }

    }
}

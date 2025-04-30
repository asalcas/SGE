using DAL;
using ENT;

namespace BL
{
    public class ListadoHeroesVillanosBL
    {
    
        /// <summary>
        /// Función que llama a la Data Access Layer y trae una lista de Objetos 'ClsHeroeVillano'
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns>  una lista : "List<ClsHeroeVillano>" </returns>
        public static List<ClsHeroeVillano> ObtenerlistadoHeroesVillanoBL()
        {
            return ListadosHeroesVillanosDAL.obtenerListadoCompleto();
        }
    }
}

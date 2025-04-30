using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL
{
    public class ListadoHeroesVillanosConPuntos
    {
        /// <summary>
        /// Función que se encargará de llamar a la Capa DAL para ofrecer el listado de Personajes con puntos
        /// PRE: NONE
        /// POST: NONE
        /// </summary>
        /// <returns> List<ClsHeroeVillanoConPuntos> </returns>
        public static List<ClsHeroeVillanoConPuntos> obtenerListadoCompletoConPuntos()
        {
            return DAL.ListadoHeroeVillanoConPuntos.obtenerlistadoCompletoHeroesVillanosConPuntos();
        }

    }
}

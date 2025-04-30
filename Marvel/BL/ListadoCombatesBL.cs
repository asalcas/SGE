using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ENT;

namespace BL
{
    public  class ListadoCombatesBL
    {
        public static List<ClsCombate> obtenerlistadoCombatesCompletoBL()
        {
            return DAL.ListadosCombatesDAL.obtenerListadoCombatesCompleto();
        }

    }
    // POR AQUI CUANDO HAGA LA LLAMADA A ACTUALIZAR UN COMBATE (MANEJADORA) TENGO QUE APLICAR LA REGLA DE NEGOCIO DEL DIA if(FechaCombate == DateTime.Today){entonces act} sino {crea}
}

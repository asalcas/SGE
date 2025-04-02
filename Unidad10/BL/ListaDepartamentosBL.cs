using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ListaDepartamentosBL
    {

        public static List<ClsDepartamentos> obtenerListadoDepartamentosBL()
        {
            // Como no tenemos regla de negocio...
            return DAL.ListaDepartamentosDAL.ObtenerListadoDepartamentosCompleto();

        }

    }
}

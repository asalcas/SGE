using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ManejadoraDepartamentosBL
    {

        public static List<ClsDepartamentos> obtenerListadoDepartamentosBL()
        {
            // Como no tenemos regla de negocio...
            return DAL.ManejadoraDepartamentosDAL.ObtenerListadoDepartamentosCompleto();

        }

    }
}

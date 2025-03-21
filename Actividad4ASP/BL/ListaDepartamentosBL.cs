using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENT;

namespace BL
{
    public class ListaDepartamentosBL
    {
        // Aqui irian las reglas de negocio creo
        public static List<ClsDepartamento> ListadoCompletoDepartamentosBL = ClsDepartamentosDAL.ObtenerListadoCompletoClsDepartamentos();

        public static List<ClsDepartamento> ObtenerListadoDepartamentosCompletoBL()
        {
            return ListadoCompletoDepartamentosBL;
        }


        
    }
    
}

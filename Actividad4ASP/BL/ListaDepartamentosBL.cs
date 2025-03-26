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
        
        public static List<ClsDepartamento> ListadoCompletoDepartamentosBL = ClsDepartamentosDAL.ObtenerListadoCompletoClsDepartamentos();
        /// <summary>
        /// Función que retorna un listado completo de Personas desde la BL
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns></returns>
        public static List<ClsDepartamento> ObtenerListadoDepartamentosCompletoBL()
        {
            return ListadoCompletoDepartamentosBL;
        }


        
    }
    
}

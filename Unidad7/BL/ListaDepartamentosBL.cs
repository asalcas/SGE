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
        
        /// <summary>
        /// Función que retorna un listado completo de Personas desde la BL
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns></returns>
        public static List<ClsDepartamento> ObtenerListadoDepartamentosCompletoBL()
        {
            return DAL.ClsDepartamentosDAL.ObtenerListadoCompletoClsDepartamentos();
        }


        
    }
    
}

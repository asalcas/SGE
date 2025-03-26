using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class ListaPersonasBL
    {

        private static List<ClsPersona> ListadoCompletoPersonasBL = ClsPersonaDAL.ObtenerListadoCompletoClsPersonaDAL();
        /// <summary>
        /// Función que retorna un listado completo de Personas desde la BL
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns>ListadoCompletoPersonasBL</returns>
        public static List<ClsPersona> ObtenerListadoCompletoPersonasBL()
        {
            return ListadoCompletoPersonasBL;
        }

    }
}

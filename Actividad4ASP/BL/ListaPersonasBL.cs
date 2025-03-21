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

        public static List<ClsPersona> ObtenerListadoCompletoPersonasBL()
        {
            return ListadoCompletoPersonasBL;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENT;

namespace BL
{
    public class ManejadoraCombateBL
    {

        public static Boolean guardarCombate(ClsCombate peleita)
        {
            Boolean exito = false;

            if (peleita.FechaCombate != DateTime.Today)
            {
                exito = ManejadoraCombatesDAL.crearCombate(peleita);
            }
            else
            {
                exito = ManejadoraCombatesDAL.actualizarCombate(peleita);
            }

            return exito;
        }

    }
}

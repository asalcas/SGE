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

        public static Boolean guardarCombateBL(ClsCombate combateMarvel)
        {
            Boolean existe = false;
            Boolean guardado = false;

            try
            {
                existe = comprobarExistenciaCombateBL(combateMarvel);
                if (existe && combateMarvel.FechaCombate == DateTime.Today)
                {

                    guardado = actualizarCombateBL(combateMarvel);

                }
                else
                {
                    guardado = crearCombateBL(combateMarvel);
                }

                

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo GUARDAR el combate", ex);
            }


            return guardado;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="combateMarvel"></param>
        /// <returns></returns>
        private static Boolean actualizarCombateBL(ClsCombate combateMarvel)
        {
            return DAL.ManejadoraCombatesDAL.actualizarCombate(combateMarvel);
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="combateMarvel"></param>
        /// <returns></returns>
        private static Boolean crearCombateBL(ClsCombate combateMarvel)
        {
            return DAL.ManejadoraCombatesDAL.crearCombate(combateMarvel);
        }
        private static Boolean comprobarExistenciaCombateBL (ClsCombate combateMarvel)
        {
            return DAL.ManejadoraCombatesDAL.comprobarExistenciaCombate(combateMarvel);
        }
    }
}

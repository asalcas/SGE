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
        /// <summary>
        /// Función que llama a la capa DAL para que guarde un combate (Aplicando los métodos privados que referencian a la DAL "crearCombate", "comprobarExistenciaCombate"
        /// "actualizarCombate"
        /// PRE: El combate que le pasamos por parametros NO PUEDE SER NULL, ya que coge la información de ahí espabilao.
        /// POST: Retornara un Booleano que nos ayudará a seguir el flujo del programa para saber si está trabajando esta función y detectar errores.
        /// </summary>
        /// <param name="combateMarvel"></param>
        /// <returns> Boolean 'guardado' = true/false </returns>
        /// <exception cref="Exception"></exception>
        public static Boolean guardarCombateBL(ClsCombate combateMarvel)
        {
            // LLEVAR ESTO A LA DAL, La fecha no es una regla de negocio, aqui llamo solo a guardar combate de la DAL
            
            return DAL.ManejadoraCombatesDAL.guardarCombate(combateMarvel);
        }

        // PASANDO LAS COMPROBACIONES SOLO EN LA DAL, TODO LO DE AQUI ABAJO, PASA A NO NECESITARSE :)

        /*
        /// <summary>
        /// Función privada que se encarga de llamar a la DAL y realizar la operación 'actualizarCombate' con el objeto 'ClsCombate' que le pasamos
        /// PRE: El combate que le pasamos por parametros NO PUEDE SER NULL.
        /// POST: Retornara un Booleano que nos ayudará a seguir el flujo del programa para saber si está trabajando esta función y detectar errores.
        /// </summary>
        /// <param name="combateMarvel"></param>
        /// <returns></returns>
        private static Boolean actualizarCombateBL(ClsCombate combateMarvel)
        {
            return DAL.ManejadoraCombatesDAL.actualizarCombate(combateMarvel);
        }

        /// <summary>
        /// Función privada que se encarga de llamar a la DAL y realizar la operación 'crearCombate' con el objeto 'ClsCombate' que le pasamos
        /// PRE: El combate que le pasamos por parametros NO PUEDE SER NULL.
        /// POST: Retornara un Booleano que nos ayudará a seguir el flujo del programa para saber si está trabajando esta función y detectar errores.
        /// </summary>
        /// <param name="combateMarvel"></param>
        /// <returns> Boolean true/false </returns>
        private static Boolean crearCombateBL(ClsCombate combateMarvel)
        {
            return DAL.ManejadoraCombatesDAL.crearCombate(combateMarvel);
        }

        /// <summary>
        /// Función privada que se encarga de llamar a la DAL y realizar la operación 'comprobarExistenciaCombate' con el objeto 'ClsCombate' que le pasamos
        /// PRE: El combate que le pasamos por parametros NO PUEDE SER NULL, sino que va a comprobar.
        /// POST: Retornara un Booleano que indicará si existe o no para tomar las decisiones a posteriori.
        /// </summary>
        /// <param name="combateMarvel"></param>
        /// <returns> Boolean true/false </returns>
        private static Boolean comprobarExistenciaCombateBL (ClsCombate combateMarvel)
        {
            return DAL.ManejadoraCombatesDAL.comprobarExistenciaCombate(combateMarvel);
        }
        */
    }
}

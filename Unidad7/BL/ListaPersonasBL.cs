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

        /// <summary>
        /// Función que retorna un listado completo de Personas desde la DAL
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns>ListadoCompletoPersonasBL</returns>
        public static List<ClsPersona> ObtenerListadoCompletoPersonasBL()
        {
            return ClsPersonaDAL.ObtenerListadoCompletoClsPersonaDAL();
        }

        // Lo ideal es que busquemos una PERSONA ALEATORIA 
        /// <summary>
        /// Funcion que devuelve una ClsPersona Aleatoria de la DAL
        /// Pre: 
        /// Post:
        /// </summary>
        /// <returns></returns>
        public static ClsPersona ObtenerPersonaAleatoria()
        {
            int idPersona;
            int numeroRandom = 0;
            // Obtener un Random de 0, al tamaño del listado
            Random rnd = new Random();
            numeroRandom = rnd.Next(0, DAL.ClsPersonaDAL.ObtenerListadoCount());

            idPersona = DAL.ClsPersonaDAL.ObtenerIdPersonaPorPosicion(numeroRandom);
            return DAL.ClsPersonaDAL.ObtenerPersonaPorID(idPersona);

        }
    }
}

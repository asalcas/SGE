using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ENT;


namespace DAL
{
    public class ClsDepartamentosDAL
    {
        private static List<ClsDepartamento> ListaCompletaDepartamentosDAL = new List<ClsDepartamento>
        {

            new ClsDepartamento(1, "Recursos Humanos"),
            new ClsDepartamento(2, "Contabilidad"),
            new ClsDepartamento(3, "Marketing"),
            new ClsDepartamento(4, "Ventas"),
            new ClsDepartamento(5, "Producción"),
            new ClsDepartamento(6, "Investigación y Desarrollo"),
            new ClsDepartamento(7, "Logística"),
            new ClsDepartamento(8, "Atención al Cliente"),
            new ClsDepartamento(9, "Tecnología de la Información"),
            new ClsDepartamento(10,"Dirección General")


        };
        /// <summary>
        /// Función que devuelve la propiedad privada 'ListaCompletaDepartamentosDAL' que simula una base de datos
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns>ListaCompletaDepartamentosDAL</returns>
        public static List<ClsDepartamento> ObtenerListadoCompletoClsDepartamentos()
        {
            return ListaCompletaDepartamentosDAL;
        }



    }
}

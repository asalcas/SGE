using ENT;

namespace DAL
{
    public class ClsPersonaDAL
    {
        
        private static List<ClsPersona> listadoPersonasCompletoDAL = new List<ClsPersona>()
        {
            new ClsPersona(10,"Alvaro", "Salvador", 0, new DateTime(2000, 4, 27), "Avenida La avenida n9", 95555555),
            new ClsPersona(11,"Ana", "López", 1, new DateTime(1995, 6, 15), "Calle del Sol n5", 9666666),
            new ClsPersona(12,"Carlos", "Martínez", 2, new DateTime(1988, 12, 5), "Plaza Mayor n3", 97777777),
            new ClsPersona(13,"Lucía", "Manzano", 3, new DateTime(1992, 8, 22), "Avenida del Mar n12", 98888888),
            new ClsPersona(14,"Pedro", "Ramírez", 4, new DateTime(1985, 11, 30), "Calle Luna n7", 99999999),
            new ClsPersona(15,"Marta", "Fernández", 5, new DateTime(1999, 3, 10), "Paseo de las Flores n2", 94444444),
            new ClsPersona(16,"Javier", "Sánchez", 6, new DateTime(2001, 7, 19), "Calle de la Sierra n14", 93333333),
            new ClsPersona(17,"Laura", "Díaz", 7, new DateTime(1997, 9, 25), "Ronda del Este n20", 92222222),
            new ClsPersona(18,"Sergio", "Torres", 8, new DateTime(1990, 5, 12), "Avenida Central n45", 91111111),
            new ClsPersona(19,"Elena", "Ruiz", 9, new DateTime(1993, 2, 18), "Callejón del Viento n8", 90000000)
        };
        /// <summary>
        /// Funcion que devuelve la propiedad privada 'listadoPersonasCompletoDAL' que simula una base de datos
        /// Pre: None
        /// Post: None
        /// </summary>
        /// <returns>listadoPersonasCompletoDAL</returns>
        public static List<ClsPersona> ObtenerListadoCompletoClsPersonaDAL()
        {
            return listadoPersonasCompletoDAL;
        }
        /// <summary>
        /// Función que busca en la lista 'listadoPersonaCompletoDal' una persona con el id que viene por parámetro
        /// Pre: El id de la persona debe existir y coincidir con una persona
        /// Post: NUNCA devuelve NULL
        /// </summary>
        /// <param name="idPersona"></param>
        /// <returns></returns>
        public static ClsPersona ObtenerPersonaPorID(int idPersona)
        {
            return listadoPersonasCompletoDAL.Find(p => p.IdPersona == idPersona);
        }

        /// <summary>
        /// Función que devuelve el tamaño del listado
        /// </summary>
        /// <returns></returns>
        public static int ObtenerListadoCount()
        {
            return listadoPersonasCompletoDAL.Count();
        }


        /// <summary>
        /// Función que devuelve el ID de una persona según su posición
        /// </summary>
        /// <param name="posicion"></param>
        /// <returns></returns>
        public static int ObtenerIdPersonaPorPosicion(int posicion)
        {
            return listadoPersonasCompletoDAL[posicion].IdPersona;
        }
    }
}

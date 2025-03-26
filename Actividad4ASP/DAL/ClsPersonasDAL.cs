using ENT;

namespace DAL
{
    public class ClsPersonaDAL
    {
        
        private static List<ClsPersona> listadoPersonasCompletoDAL = new List<ClsPersona>()
        {
            new ClsPersona("Alvaro", "Salvador", 0, new DateTime(2000, 4, 27), "Avenida La avenida n9", 95555555),
            new ClsPersona("Ana", "López", 1, new DateTime(1995, 6, 15), "Calle del Sol n5", 9666666),
            new ClsPersona("Carlos", "Martínez", 2, new DateTime(1988, 12, 5), "Plaza Mayor n3", 97777777),
            new ClsPersona("Lucía", "Manzano", 3, new DateTime(1992, 8, 22), "Avenida del Mar n12", 98888888),
            new ClsPersona("Pedro", "Ramírez", 4, new DateTime(1985, 11, 30), "Calle Luna n7", 99999999),
            new ClsPersona("Marta", "Fernández", 5, new DateTime(1999, 3, 10), "Paseo de las Flores n2", 94444444),
            new ClsPersona("Javier", "Sánchez", 6, new DateTime(2001, 7, 19), "Calle de la Sierra n14", 93333333),
            new ClsPersona("Laura", "Díaz", 7, new DateTime(1997, 9, 25), "Ronda del Este n20", 92222222),
            new ClsPersona("Sergio", "Torres", 8, new DateTime(1990, 5, 12), "Avenida Central n45", 91111111),
            new ClsPersona("Elena", "Ruiz", 9, new DateTime(1993, 2, 18), "Callejón del Viento n8", 90000000)
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
    }
}

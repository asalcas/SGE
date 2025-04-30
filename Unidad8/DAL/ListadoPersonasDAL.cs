using ENT;
namespace DAL
{
    public class ListadoPersonasDAL
    {


        private static List<ClsPersona> listadoPersonas = new()
        {
            new ClsPersona ("Alvaro","Salvador",24 , "Avenida avenida", "gmailaleatorio@email.com"),
            new ClsPersona("Maria", "Lopez", 30, "Calle Primavera", "maria.lopez@email.com"),
            new ClsPersona("Juan", "Perez", 28, "Avenida Central", "juan.perez@email.com"),
            new ClsPersona("Lucia", "Manzano", 22, "Boulevard del Sol", "lucia.martinez@email.com"),
            new ClsPersona("Carlos", "Gomez", 35, "Pasaje de la Luna", "carlos.gomez@email.com"),
            new ClsPersona("Elena", "Torres", 27, "Plaza Mayor", "elena.torres@email.com")
        };

        /// <summary>
        /// Funcion para devolver 'listadoPersonas' a la BL
        /// </summary>
        /// <returns></returns>
        public static List<ClsPersona> ObtenerListadoCompletoDAL()
        {
            return listadoPersonas;
        }
    }
}

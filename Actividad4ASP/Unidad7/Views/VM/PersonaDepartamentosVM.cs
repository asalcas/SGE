using ENT;

namespace Actividad4ASP.Views.VM
{
    // ESTO ES UNA CLASE INTERMEDIARIA ENTRE CLS DEPT Y CLS PERSONA PARA ESTO
    public class PersonaDepartamentosVM
    {

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }
        public string NombreDept { get; set; }

        // el int idPersona no deberia de setearse si no quiero hacer lo del paso de datos de un action a otro, preguntar a fernando
        public PersonaDepartamentosVM(int idPersona, string nombre, string apellido, DateTime fechaNac, string direccion, long telefono, string nombreDept)
        {
            IdPersona = idPersona; // no se si este deberia tenerlo!
            Nombre = nombre;
            Apellido = apellido;
            FechaNac = fechaNac;
            Direccion = direccion;
            Telefono = telefono;
            NombreDept = nombreDept;
        }
    }
}

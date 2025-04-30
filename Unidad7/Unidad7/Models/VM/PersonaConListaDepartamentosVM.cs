using ENT;

namespace Actividad4ASP.Models.VM
{
    // ESTO ES UNA CLASE INTERMEDIARIA ENTRE CLS DEPT Y CLS PERSONA PARA ESTO
    public class PersonaConListaDepartamentosVM : ClsPersona
    {

        public List<ClsDepartamento> ListaDeDept { get; }

        // el int idPersona no deberia de setearse si no quiero hacer lo del paso de datos de un action a otro, preguntar a fernando
        // COGEMOS LOS ATRIBUTOS DE LA CLAE BASE con BASE()
        public PersonaConListaDepartamentosVM(ClsPersona persona, List<ClsDepartamento> departamentos)
            : base(persona.IdPersona, persona.Nombre, persona.Apellido, persona.IdDepartamento, persona.FechaNac, persona.Direccion, persona.Telefono)
        {

            ListaDeDept = departamentos;
        }
        public PersonaConListaDepartamentosVM(ClsPersona persona)
            : base(persona.IdPersona, persona.Nombre, persona.Apellido, persona.IdDepartamento, persona.FechaNac, persona.Direccion, persona.Telefono)
        {
            ListaDeDept = BL.ListaDepartamentosBL.ObtenerListadoDepartamentosCompletoBL();
        }

    }
}

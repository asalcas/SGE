using ENT;

namespace Actividad2ASP.Models.VM
{
    public class PersonaConNombreDepartamentoVM : ClsPersona
    {
        public String NombreDept { get; }


        public PersonaConNombreDepartamentoVM()
        {

        }
        public PersonaConNombreDepartamentoVM(ClsPersona persona, List<ClsDepartamentos> listadoDepartamentos) : base(persona.ID, persona.Nombre, persona.Apellidos, persona.Sexo, persona.Foto, persona.FechaNacimiento)
        {
            // TODO: Buscar en el parametro que me llega como listado, el nombre de la raza que necesito
            this.NombreDept = ;
        }

    }

}

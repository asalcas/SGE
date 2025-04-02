using ENT;

namespace Actividad2ASP.Models.VM
{
    public class PersonaConNombreDepartamentoVM : ClsPersona
    {
        public String NombreDept { get; }


        public PersonaConNombreDepartamentoVM()
        {

        }
        
        public PersonaConNombreDepartamentoVM(ClsPersona persona, List<ClsDepartamentos> listadoDepartamentos) : base(persona.ID, persona.Nombre, 
            persona.Telefono, persona.Apellidos, persona.Direccion, persona.Foto, persona.FechaNacimiento, persona.IdDept)
        {
            ClsDepartamentos departamentoSeleccionado = listadoDepartamentos.Find(departamento => departamento.IdDepartamento == persona.IdDept);
            this.NombreDept = departamentoSeleccionado.NombreDepartamento;
        }

    }

}

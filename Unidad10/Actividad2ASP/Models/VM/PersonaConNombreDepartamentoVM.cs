using ENT;

namespace Actividad2ASP.Models.VM
{
    public class PersonaConNombreDepartamentoVM : ClsPersona
    {
        public String NombreDept { get; }
        public List<ClsDepartamentos> listadoDepartamentosParaVista { get; } // Lo he creado solo para poder hacer un seleccionable de la lista en la vista no se si está mal


        public PersonaConNombreDepartamentoVM()
        {

        }
        
        public PersonaConNombreDepartamentoVM(ClsPersona persona, List<ClsDepartamentos> listadoDepartamentos) : base(persona.ID, persona.Nombre, persona.Apellidos,
            persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento, persona.IdDept)
        {
            this.listadoDepartamentosParaVista = listadoDepartamentos;
            ClsDepartamentos departamentoSeleccionado = listadoDepartamentos.Find(departamento => departamento.IdDepartamento == persona.IdDept);
            this.NombreDept = departamentoSeleccionado.NombreDepartamento;
        }

    }

}

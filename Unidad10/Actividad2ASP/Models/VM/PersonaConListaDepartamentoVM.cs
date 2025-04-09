using ENT;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Actividad2ASP.Models.VM
{
    public class PersonaConListaDepartamentoVM : ClsPersona
    {
        [Display(Name ="Departamento")]
        public String NombreDept { get; }
        public ClsDepartamentos departamentoSelected { get; set; }
        public List<ClsDepartamentos> listadoDepartamentosParaVista { get; } // Lo he creado solo para poder hacer un seleccionable de la lista en la vista no se si está mal


        public PersonaConListaDepartamentoVM()
        {

        }
        
        public PersonaConListaDepartamentoVM(ClsPersona persona, List<ClsDepartamentos> listadoDepartamentos) : base(persona.ID, persona.Nombre, persona.Apellidos,
            persona.Telefono, persona.Direccion, persona.Foto, persona.FechaNacimiento, persona.IdDept)
        {
            this.listadoDepartamentosParaVista = listadoDepartamentos;
            ClsDepartamentos departamentoSeleccionado = listadoDepartamentos.Find(departamento => departamento.IdDepartamento == persona.IdDept);
            this.NombreDept = departamentoSeleccionado.NombreDepartamento;
        }

    }

}

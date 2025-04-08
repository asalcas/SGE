using ENT;
using System.Collections.ObjectModel;

namespace Actividad2ASP.Models.VM
{
    public class ListadoPersonasConNombreDeptVM
    {
        public ObservableCollection<PersonaConNombreDepartamentoVM> ListadoDePersonasConNombreDept { get; }


        /// <summary>
        /// Constructor que al instanciarse, se rellenará automáticamente con las dos listas de la BL, Personas y Departamentos
        /// </summary>
        /// <returns></returns>
        public ListadoPersonasConNombreDeptVM()
        {

            try
            {
                List<ClsPersona> listadoPersonasBL = BL.ManejadoraPersonasBL.ObtenerListaPersonasCompletaBL();
                List<ClsDepartamentos> listadoDepartamentosBL = BL.ManejadoraDepartamentosBL.obtenerListadoDepartamentosBL();

                ListadoDePersonasConNombreDept = new ObservableCollection<PersonaConNombreDepartamentoVM>();


                // Recorro el listado de personas, y voy rellenando el VM

                foreach (ClsPersona persona in listadoPersonasBL)
                {
                    PersonaConNombreDepartamentoVM personaNueva = new(persona, listadoDepartamentosBL);
                    ListadoDePersonasConNombreDept.Add(personaNueva);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}

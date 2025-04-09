using Actividad2ASP.Models.VM;
using BL;
using ENT;
using Microsoft.Data.SqlClient;

namespace Actividad2ASP.Models.Utils
{
    public class PresetPersonaConNombreDepartamento
    {
        public static PersonaConListaDepartamentoVM mostrarPersonaSeleccionada(int idPersona)
        {
            PersonaConListaDepartamentoVM personaEditar = null;
            try
            {
                ClsPersona personaNormal = ManejadoraPersonasBL.ObtenerPersonaPorID(idPersona);
                List<ClsDepartamentos> listadoDepartamentos = ManejadoraDepartamentosBL.obtenerListadoDepartamentosBL();
                personaEditar = new PersonaConListaDepartamentoVM(personaNormal, listadoDepartamentos);

            }
            catch (SqlException e)
            {
                throw e;
            }
            return personaEditar;
        }
    }
}

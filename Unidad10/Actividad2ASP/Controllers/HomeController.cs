using Actividad2ASP.Models.Utils;
using Actividad2ASP.Models.VM;
using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.Metrics;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Actividad2ASP.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            ListadoPersonasConNombreDeptVM listadoASubir = new();

            return View(listadoASubir.ListadoDePersonasConNombreDept);
        }

        public IActionResult EditarPersona(int idPersona)
        {
            PersonaConListaDepartamentoVM personaEditar = PresetPersonaConNombreDepartamento.mostrarPersonaSeleccionada(idPersona);
            return View(personaEditar);
        }

        public IActionResult DetallesPersona(int idPersona)
        {
            PersonaConListaDepartamentoVM personaDetalles = PresetPersonaConNombreDepartamento.mostrarPersonaSeleccionada(idPersona);
            return View(personaDetalles);
        }
        

         
    }
}

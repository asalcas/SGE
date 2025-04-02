using Actividad2ASP.Models.VM;
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

        public IActionResult EditarPersona()
        {
            return View();
        }

       
    }
}

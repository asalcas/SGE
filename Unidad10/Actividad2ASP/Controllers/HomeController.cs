using ENT;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Actividad2ASP.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {

            List<ClsPersona> ListaDePersonas = BL.ListaPersonasBL.ObtenerListaPersonasCompletaBL();

            return View(ListaDePersonas);
        }

        public IActionResult EditarPersona()
        {
            return View();
        }

       
    }
}

using Actividad3ASP.Models;
using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Actividad3ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            // Aqui iría las cosa que irian en un Index :)


            return View();
        }
        public IActionResult Editar()
        {
            Random random = new Random();
            List<ClsPersona> listaPersonas = ListadoPersonasBL.ObtenerlistadoCompletoPersonasBL();
            int numeroRandom = random.Next(0, listaPersonas.Count());

            ClsPersona personaSeleccionada = listaPersonas[numeroRandom];


            return View(personaSeleccionada);
        }
        public IActionResult PersonaModificada(String nombre, String apellido, int edad, String direccion, String email)
        {

            ClsPersona personaEditada = new(nombre, apellido, edad, direccion, email);
            return View(personaEditada);
        }
    }
}

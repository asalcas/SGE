using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspMVC.Controllers
{
    public class ProductosController : Controller
    {
        // GET: ListadoProductos
        public IActionResult ListadoProductos()
        {
            return View();
        }
    }
}

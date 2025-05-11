using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InverASP.Controllers
{
    public class InvernaderoController : Controller
    {
        // GET: InvernaderoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InvernaderoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvernaderoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvernaderoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvernaderoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvernaderoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InvernaderoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvernaderoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

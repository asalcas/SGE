using BL;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Actividad2ASP.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            List<ClsPersona> listadoPersonas;
            try
            {
                 listadoPersonas = ManejadoraPersonasBL.ObtenerListaPersonasCompletaBL();
            }catch (Exception e)
            {
                return View("Error");
            }

            return View(listadoPersonas);
        }

        // GET: PersonasController/Details/5
        public ActionResult DetallesPersona(int idPersona)
        {
            ClsPersona personaDetalles = null;
            try
            {
                personaDetalles = ManejadoraPersonasBL.ObtenerPersonaPorID(idPersona);

            }
            catch (Exception e)
            {
                return View("Error");
            }
            return View(personaDetalles);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClsPersona personaInsertar)
        {
            try
            {
                try
                {

                    ManejadoraPersonasBL.insertarPersonaBL(personaInsertar);

                }catch(SqlException e)
                {
                    return View("Error");
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int idPersona)
        {

            ClsPersona personaEditar = null;
            try
            {
                personaEditar = ManejadoraPersonasBL.ObtenerPersonaPorID(idPersona);

            }
            catch (Exception e)
            {
                return View("Error");
            }

            return View(personaEditar);
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID, ClsPersona personaFormulario)
        {

            try
            {
                // Monto una persona nueva por que no funciona sino, no se como hacerlo siempre tiene ID 0 si no lo hago
                ClsPersona personaEditar = new ClsPersona(ID);
                if (personaEditar.ID == ID)
                {
                    personaEditar.Nombre = personaFormulario.Nombre;
                    personaEditar.Apellidos = personaFormulario.Apellidos;
                    personaEditar.Telefono = personaFormulario.Telefono;
                    personaEditar.Direccion = personaFormulario.Direccion;
                    personaEditar.Foto = personaFormulario.Foto;
                    personaEditar.FechaNacimiento = personaFormulario.FechaNacimiento;
                    personaEditar.IdDept = personaFormulario.IdDept;
                }
                ManejadoraPersonasBL.actualizarPersonaBL(personaEditar);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int idPersona)
        {

            ClsPersona personaEliminar;
            try
            {
                personaEliminar = ManejadoraPersonasBL.ObtenerPersonaPorID(idPersona);
            }
            catch (SqlException e)
            {
                throw e;
            }
            return View(personaEliminar);
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ID, IFormCollection collection)
        {
            Boolean borrado = false;
            try
            {
                borrado = ManejadoraPersonasBL.borrarPersonaBL(ID);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

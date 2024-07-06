using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Obligatorio2.Datos;
using Obligatorio2.Models;

namespace Obligatorio2.Controllers
{
    public class RutinaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RutinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListRutina()
        {
            var rutinas = _context.rutinas.ToList();
            return View(rutinas);
        }

        public IActionResult AddRutina()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRutina(Rutina r)
        {
            _context.rutinas.Add(r);
            _context.SaveChanges();
            return RedirectToAction("ListRutina");
        }

        [HttpPost]
        public IActionResult DeleteRutina(int IdRutina)
        {
            Rutina r = _context.rutinas.Find(IdRutina);
            _context.rutinas.Remove(r);
            _context.SaveChanges();
            return RedirectToAction("ListRutina");
        }

        public IActionResult UpdateRutina(int id)
        {
            Rutina r = _context.rutinas.Find(id);
            return View(r);
        }

        [HttpPost]
        public IActionResult UpdateRutina(Rutina r)
        {
            _context.rutinas.Update(r);
            _context.SaveChanges();
            return RedirectToAction("ListRutina");
        }
       
    }
}

using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Datos;
using Obligatorio2.Models;

namespace Obligatorio2.Controllers
{
    public class LocalController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LocalController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListLocal()
        {
            var locales = _context.locales.ToList();
            return View(locales);
        }

        public IActionResult AddLocal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLocal(Local l)
        {
            _context.locales.Add(l);
            _context.SaveChanges();
            return RedirectToAction("ListLocal");
        }

        [HttpPost]
        public IActionResult DeleteLocal(int IdLocal)
        {
            Local l = _context.locales.Find(IdLocal);
            _context.locales.Remove(l);
            _context.SaveChanges();
            return RedirectToAction("ListLocal");
        }

        public IActionResult UpdateLocal(int id)
        {
            Local l = _context.locales.Find(id);
            if (l == null)
            {
                return NotFound();
            }
            return View(l);
        }

        [HttpPost]
        public IActionResult UpdateLocal(Local l)
        {
           // if (ModelState.IsValid)
            //{
                _context.locales.Update(l);
                _context.SaveChanges();
                return RedirectToAction("ListLocal");
            //}
            //return View();
        }
    }
}

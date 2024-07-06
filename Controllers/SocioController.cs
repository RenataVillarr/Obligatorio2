using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Obligatorio2.Datos;
using Obligatorio2.Models;
using System.Linq;
using System.Collections.Generic;

namespace Obligatorio2.Controllers
{
    public class SocioController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SocioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListSocio()
        {
            var socios = _context.socios.ToList();
            return View(socios);
        }

        public IActionResult AddSocio()
        {
            var locales = _context.locales.ToList();
            List<SelectListItem> RecolectoLocal = new List<SelectListItem>();
            foreach(Local local in locales)
            {
                RecolectoLocal.Add(new SelectListItem { Text = local.IdLocal.ToString(), Value = local.IdLocal.ToString(), Selected = false });
            }
            Socio localSocio = new Socio { LocalesPosibles = RecolectoLocal };
            return View(localSocio);
        }

        [HttpPost]
        public IActionResult AddSocio(Socio s)
        {
            _context.socios.Add(s);
            _context.SaveChanges();
            return RedirectToAction("ListSocio");
        }

        [HttpPost]
        public IActionResult DeleteSocio(int IdSocio)
        {
            Socio s = _context.socios.Find(IdSocio);
            _context.socios.Remove(s);
            _context.SaveChanges();
            return RedirectToAction("ListSocio");
        }

        public IActionResult UpdateSocio(int id)
        {
            
            Socio s = _context.socios.Find(id);
            if (s == null)
            {
                return NotFound();
            }

            var locales = _context.locales.ToList();
            List<SelectListItem> RecolectoLocal = new List<SelectListItem>();
            foreach (Local local in locales)
            {
                RecolectoLocal.Add(new SelectListItem { Text = local.IdLocal.ToString(), Value = local.IdLocal.ToString(), Selected = local.IdLocal == s.IdLocal });
            }
            s.LocalesPosibles = RecolectoLocal;

            return View(s);
        }

        /* public IActionResult UpdateSocio(int IdSocio)
         {
             Socio s = _context.socios.Find(IdSocio);
             return View(s);
         }*/

        [HttpPost]
        public IActionResult UpdateSocio(Socio s)
        {
            _context.socios.Update(s);
            _context.SaveChanges();
            return RedirectToAction("ListSocio");
        }
    }
}

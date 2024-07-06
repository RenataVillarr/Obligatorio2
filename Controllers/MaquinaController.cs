using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Obligatorio2.Datos;
using Obligatorio2.Models;

namespace Obligatorio2.Controllers
{
    public class MaquinaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MaquinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListMaquina()
        {
            var maquinas = _context.maquinas.ToList();
            return View(maquinas);
        }

        public IActionResult AddMaquina()
        {
            var locales = _context.locales.ToList(); 
            var tipomaquinas = _context.tipomaquinas.ToList(); 

            List<SelectListItem> RecolectoLocal = new List<SelectListItem>();
            foreach (var local in locales)
            {
                RecolectoLocal.Add(new SelectListItem { Text = local.IdLocal.ToString(), Value = local.IdLocal.ToString(), Selected = false });
            }

            List<SelectListItem> RecolectoTipoMaq = new List<SelectListItem>();
            foreach (var tipoMaquina in tipomaquinas)
            {
                RecolectoTipoMaq.Add(new SelectListItem { Text = tipoMaquina.IdTipoMaq.ToString(), Value = tipoMaquina.IdTipoMaq.ToString(), Selected = false });
            }

            var maquina = new Maquina
            {
                LocalesPosibles = RecolectoLocal,
                TipoMaqsPosibles = RecolectoTipoMaq
            };

            return View(maquina);
        }

        [HttpPost]
        public IActionResult AddMaquina(Maquina m)
        {
            _context.maquinas.Add(m);
            _context.SaveChanges();
            return RedirectToAction("ListMaquina");
        }

        [HttpPost]
        public IActionResult DeleteMaquina(int IdMaq)
        {
            Maquina m = _context.maquinas.Find(IdMaq);
            _context.maquinas.Remove(m);
            _context.SaveChanges();
            return RedirectToAction("ListMaquina");
        }

        public IActionResult UpdateMaquina(int id)
        {
            Maquina m = _context.maquinas.Find(id);
            if (m == null)
            {
                return NotFound();
            }

            var locales = _context.locales.ToList();
            var tipomaquinas = _context.tipomaquinas.ToList();
            List<SelectListItem> RecolectoLocal = new List<SelectListItem>();
            foreach (Local local in locales)
            {
                RecolectoLocal.Add(new SelectListItem { Text = local.IdLocal.ToString(), Value = local.IdLocal.ToString(), Selected = local.IdLocal == m.IdLocal });
            }
            List<SelectListItem> RecolectoTipoMaq = new List<SelectListItem>();
            foreach (TipoMaquina tipomaquina in tipomaquinas)
            {
                RecolectoTipoMaq.Add(new SelectListItem { Text = tipomaquina.IdTipoMaq.ToString(), Value = tipomaquina.IdTipoMaq.ToString(), Selected = tipomaquina.IdTipoMaq == m.IdTipoMaq });
            }
            m.LocalesPosibles = RecolectoLocal;
            m.TipoMaqsPosibles = RecolectoTipoMaq;

            return View(m);
        }
    

        [HttpPost]
        public IActionResult UpdateMaquina(Maquina m)
        {
            
                _context.maquinas.Update(m);
                _context.SaveChanges();
                return RedirectToAction("ListMaquina");
           
        }
    }
}

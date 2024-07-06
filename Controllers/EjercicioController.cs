using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Datos;
using Obligatorio2.Models;

namespace Obligatorio2.Controllers
{
    public class EjercicioController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EjercicioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListEjercicio()
        {
            var ejercicios = _context.ejercicios.ToList();
            return View(ejercicios);
        }

        public IActionResult AddEjercicio()
        {
            var tipomaquinas = _context.tipomaquinas.ToList();
            List<SelectListItem> RecolectoTipoMaq = new List<SelectListItem>();
            foreach (TipoMaquina tipoMaquina in tipomaquinas)
            {
                RecolectoTipoMaq.Add(new SelectListItem { Text = tipoMaquina.IdTipoMaq.ToString(), Value = tipoMaquina.IdTipoMaq.ToString(), Selected = false });
            }
            Ejercicio tipomaqEjer = new Ejercicio { TipoMaqsPosibles = RecolectoTipoMaq };
            return View(tipomaqEjer);
        }

        [HttpPost]
        public IActionResult AddEjercicio(Ejercicio e)
        {
            _context.ejercicios.Add(e);
            _context.SaveChanges();
            return RedirectToAction("ListEjercicio");
        }

        [HttpPost]
        public IActionResult DeleteEjercicio(int IdEjercicio)
        {
            Ejercicio e = _context.ejercicios.Find(IdEjercicio);
            _context.ejercicios.Remove(e);
            _context.SaveChanges();
            return RedirectToAction("ListEjercicio");
        }

        public IActionResult UpdateEjercicio(int id)
        {
            Ejercicio e = _context.ejercicios.Find(id);
            if (e == null)
            {
                return NotFound();
            }

            var tipomaquinas = _context.tipomaquinas.ToList();
            List<SelectListItem> RecolectoTipoMaq = new List<SelectListItem>();
            foreach (TipoMaquina tipomaquina in tipomaquinas)
            {
                RecolectoTipoMaq.Add(new SelectListItem { Text = tipomaquina.IdTipoMaq.ToString(), Value = tipomaquina.IdTipoMaq.ToString(), Selected = tipomaquina.IdTipoMaq == e.IdTipoMaq });
            }
            e.TipoMaqsPosibles = RecolectoTipoMaq;

            return View(e);
        }


        [HttpPost]
        public IActionResult UpdateEjercicio(Ejercicio e)
        {
            _context.ejercicios.Update(e);
            _context.SaveChanges();
            return RedirectToAction("ListEjercicio");
        }
    }
}

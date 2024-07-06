using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obligatorio2.Datos;
using Obligatorio2.Models;

namespace Obligatorio2.Controllers
{
    public class RutinaEjercicioController : Controller
    {
        ApplicationDbContext _context;
        public RutinaEjercicioController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ListRutinaEjercicio()
        {
            var rutinaejercicio = _context.rutinaejercicios.Include(re => re.Rutina).Include(re => re.Ejercicio).ToList();
            return View(rutinaejercicio);
        }

        public IActionResult AddRutinaEjercicio()
        {
            var rutinas = _context.rutinas.ToList();
            var ejercicios = _context.ejercicios.ToList();
            List<SelectListItem> RecolectoRutinas = new List<SelectListItem>();
            List<SelectListItem> RecolectoEjercicios = new List<SelectListItem>();

            foreach (Rutina r in rutinas)
            {
                RecolectoRutinas.Add(new SelectListItem { Value = r.IdRutina.ToString(), Text = r.Descripcion, Selected = false });
            }
            foreach (Ejercicio e in ejercicios)
            {
                RecolectoEjercicios.Add(new SelectListItem { Value = e.IdEjercicio.ToString(), Text = e.Descripcion, Selected = false });
            }

            RutinaEjercicio Modelo = new RutinaEjercicio { RutinasPosibles = RecolectoRutinas, EjerciciosPosibles = RecolectoEjercicios };

            return View(Modelo);
        }
        [HttpPost]
        public IActionResult AddRutinaEjercicio(RutinaEjercicio re)
        {
            _context.rutinaejercicios.Add(re);
            _context.SaveChanges();
            return RedirectToAction("ListRutinaEjercicio");
        }
        [HttpPost]
        public IActionResult DeleteRutinaEjercicio(int idRutina, int idEjercicio)
        {

            RutinaEjercicio re = _context.rutinaejercicios.Find(idRutina, idEjercicio);
            _context.rutinaejercicios.Remove(re);
            _context.SaveChanges();
            return RedirectToAction("ListRutinaEjercicio");
        }

        public IActionResult UpdateRutinaEjercicio(int idRutina, int idEjercicio)
        {
            RutinaEjercicio re = _context.rutinaejercicios.Find(idRutina, idEjercicio);
            var rutinas = _context.rutinas.ToList();
            var ejercicios = _context.ejercicios.ToList();
            List<SelectListItem> RecolectoRutinas = new List<SelectListItem>();
            List<SelectListItem> RecolectoEjercicios = new List<SelectListItem>();

            foreach (Rutina r in rutinas)
            {
                if (r.IdRutina == re.Rutina.IdRutina)
                    RecolectoRutinas.Add(new SelectListItem { Value = r.IdRutina.ToString(), Text = r.Descripcion, Selected = true });
                else
                    RecolectoRutinas.Add(new SelectListItem { Value = r.IdRutina.ToString(), Text = r.Descripcion, Selected = false });
            }
            foreach (Ejercicio e in ejercicios)
            {
                if (e.IdEjercicio == re.Ejercicio.IdEjercicio)
                    RecolectoEjercicios.Add(new SelectListItem { Value = e.IdEjercicio.ToString(), Text = e.Descripcion, Selected = true });
                else
                    RecolectoEjercicios.Add(new SelectListItem { Value = e.IdEjercicio.ToString(), Text = e.Descripcion, Selected = false });

            }

            return View(re);
        }
        [HttpPost]
        public IActionResult UpdateRutinaEjercicio(RutinaEjercicio re)
        {
            _context.rutinaejercicios.Add(re);
            _context.SaveChanges();
            return RedirectToAction("ListRutinaEjercicio");
        }
    }
}

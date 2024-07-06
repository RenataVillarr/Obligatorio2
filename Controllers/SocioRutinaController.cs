using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obligatorio2.Datos;
using Obligatorio2.Models;


namespace Obligatorio2Programacion3.Controllers
{
    public class SocioRutinaController : Controller
    {
        ApplicationDbContext _context;
        public SocioRutinaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ListSocioRutina()
        {
            var sociorutina = _context.sociorutinas.Include(sr => sr.Socio).Include(sr => sr.Rutina).ToList();
            return View(sociorutina);
        }

        public IActionResult AddSocioRutina()
        {
            var socios = _context.socios.ToList();
            var rutinas = _context.rutinas.ToList();
            List<SelectListItem> RecolectoSocios = new List<SelectListItem>();
            List<SelectListItem> RecolectoRutinas = new List<SelectListItem>();

            foreach (Socio s in socios)
            {
                RecolectoSocios.Add(new SelectListItem { Value = s.IdSocio.ToString(), Text = s.Nombre, Selected = false });
            }
            foreach (Rutina r in rutinas)
            {
                RecolectoRutinas.Add(new SelectListItem { Value = r.IdRutina.ToString(), Text = r.Descripcion, Selected = false });
            }

            SocioRutina Modelo = new SocioRutina { SociosPosibles = RecolectoSocios, RutinasPosibles = RecolectoRutinas };

            return View(Modelo);
        }
        [HttpPost]
        public IActionResult AddSocioRutina(SocioRutina sr)
        {
            _context.sociorutinas.Add(sr);
            _context.SaveChanges();
            UpdateCalifRutinaPromedio(sr.IdRutina);
            return RedirectToAction("ListSocioRutina");
        }
        [HttpPost]
        public IActionResult DeleteSocioRutina(int idSocio, int idRutina)
        {

            SocioRutina sr = _context.sociorutinas.Find(idSocio, idRutina);
            _context.sociorutinas.Remove(sr);
            _context.SaveChanges();
            UpdateCalifRutinaPromedio(sr.IdRutina);
            return RedirectToAction("ListSocioRutina");
        }

        public IActionResult UpdateSocioRutina(int idSocio, int idRutina)
        {
            SocioRutina sr = _context.sociorutinas.Find(idSocio, idRutina);
            var socios = _context.socios.ToList();
            var rutinas = _context.rutinas.ToList();
            List<SelectListItem> RecolectoSocios = new List<SelectListItem>();
            List<SelectListItem> RecolectoRutinas = new List<SelectListItem>();

            foreach (Socio s in socios)
            {
                if (s.IdSocio == sr.Socio.IdSocio)
                    RecolectoSocios.Add(new SelectListItem { Value = s.IdSocio.ToString(), Text = s.Nombre, Selected = true });
                else
                    RecolectoSocios.Add(new SelectListItem { Value = s.IdSocio.ToString(), Text = s.Nombre, Selected = false });
            }
            foreach (Rutina r in rutinas)
            {
                if (r.IdRutina == sr.Rutina.IdRutina)
                    RecolectoRutinas.Add(new SelectListItem { Value = r.IdRutina.ToString(), Text = r.Descripcion, Selected = true });
                else
                    RecolectoRutinas.Add(new SelectListItem { Value = r.IdRutina.ToString(), Text = r.Descripcion, Selected = false });

            }

            return View(sr);
        }
        [HttpPost]
        public IActionResult UpdateSocioRutina(SocioRutina sr)
        {
            _context.sociorutinas.Add(sr);
            _context.SaveChanges();
            UpdateCalifRutinaPromedio(sr.IdRutina);
            return RedirectToAction("ListSocioRutina");
        }
        private void UpdateCalifRutinaPromedio(int idRutina)
        {
            var rutinas = _context.rutinas.Find(idRutina);
            if (rutinas != null)
            {
                var sociorutinas = _context.sociorutinas.Where(sr => sr.IdRutina == idRutina).ToList();
                rutinas.ActualizarPromedioCalificacion(sociorutinas);
                _context.rutinas.Update(rutinas);
                _context.SaveChanges();
            }
        }
    }
}

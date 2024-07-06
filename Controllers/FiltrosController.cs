using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Datos;
using Obligatorio2.Models;

namespace Obligatorio2.Controllers
{
    public class FiltrosController : Controller
    {
        ApplicationDbContext _context;
        public FiltrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult SociosSinRutinasXTipoMaquina(string tipoMaquina)
        {
            if (string.IsNullOrEmpty(tipoMaquina))
            {
                ViewBag.Socios = new List<Socio>();
                ViewBag.TipoMaquina = tipoMaquina;
                return View();
            }

            // Obtener los IDs de los ejercicios con el tipo de máquina especificado
            var ejercicioIdsConTipoMaquina = _context.ejercicios
                .Where(e => e.TipoMaquina.Nombre == tipoMaquina)
                .Select(e => e.IdEjercicio)
                .ToList();

            // Obtener los IDs de las rutinas que contienen esos ejercicios
            var rutinaIdsConTipoMaquina = _context.rutinaejercicios
                .Where(re => ejercicioIdsConTipoMaquina.Contains(re.IdEjercicio))
                .Select(re => re.IdRutina)
                .Distinct()
                .ToList();

            // Obtener los IDs de los socios que han realizado rutinas con esos ejercicios
            var sociosConRutinasConTipoMaquina = _context.sociorutinas
                .Where(sr => rutinaIdsConTipoMaquina.Contains(sr.IdRutina))
                .Select(sr => sr.IdSocio)
                .Distinct()
                .ToList();

            // Obtener los socios que no están en la lista anterior
            var sociosSinRutinasXTipoMaquina = _context.socios
                .Where(s => !sociosConRutinasConTipoMaquina.Contains(s.IdSocio))
                .ToList();

            ViewBag.TipoMaquina = tipoMaquina;
            ViewBag.Socios = sociosSinRutinasXTipoMaquina;

            return View();
        }


    }
}

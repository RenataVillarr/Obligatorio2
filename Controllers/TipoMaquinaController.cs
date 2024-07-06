using Microsoft.AspNetCore.Mvc;
using Obligatorio2.Datos;
using Obligatorio2.Models;

namespace Obligatorio2.Controllers
{
    public class TipoMaquinaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TipoMaquinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ListTipoMaq()
        {
            var tipomaquinas = _context.tipomaquinas.ToList();
            return View(tipomaquinas);
        }

        public IActionResult AddTipoMaq()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTipoMaq(TipoMaquina tm)
        {
            _context.tipomaquinas.Add(tm);
            _context.SaveChanges();
            return RedirectToAction("ListTipoMaq");
        }

        [HttpPost]
        public IActionResult DeleteTipoMaq(int IdTipoMaq)
        {
            TipoMaquina tm  = _context.tipomaquinas.Find(IdTipoMaq);
            _context.tipomaquinas.Remove(tm);
            _context.SaveChanges();
            return RedirectToAction("ListTipoMaq");
        }

        //public IActionResult UpdateTipoMaq(int IdTipoMaq)
        //{
        //    Console.WriteLine(IdTipoMaq);

        //    TipoMaquina tm = _context.tipomaquinas.Find(IdTipoMaq);
        //    return View(tm);
        //}
        // EL NOMBRE DEL PARAMETRO id TIENE QUE SER EL MISMO QUE EL ESPECIFICADO EN ListTipoMaq EN EL BOTON DE SUBMIT (asp-route-id)
        
        public IActionResult UpdateTipoMaq(int id)
        {
            Console.WriteLine(id);

            TipoMaquina tm = _context.tipomaquinas.Find(id);
            return View(tm);
        }


        [HttpPost]
        public IActionResult UpdateTipoMaq(TipoMaquina tm)
        {
            _context.tipomaquinas.Update(tm);
            _context.SaveChanges();
            return RedirectToAction("ListTipoMaq");
        }
    }
}

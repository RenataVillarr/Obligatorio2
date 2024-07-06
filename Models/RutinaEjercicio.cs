using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio2.Models
{
    public class RutinaEjercicio
    {
        [ForeignKey("Rutina")]
        [Required(ErrorMessage = "La rutina es obligatoria")]
        public int IdRutina { get; set; }
        [ValidateNever]
        public Rutina Rutina { get; set; }

        [ValidateNever]
        public List<SelectListItem> RutinasPosibles { get; set; }

        [ForeignKey("Ejercicio")]
        [Required(ErrorMessage = "El ejercicio es obligatorio")]
        public int IdEjercicio { get; set; }
        [ValidateNever]
        public Ejercicio Ejercicio { get; set; }

        [ValidateNever]
        public List<SelectListItem> EjerciciosPosibles { get; set; }
        public int Cantidad { get; set; }
    }
}

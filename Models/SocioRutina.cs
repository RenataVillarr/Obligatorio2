using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Obligatorio2.Models
{
    public class SocioRutina
    {
        [ForeignKey("Socio")]
        [Required(ErrorMessage = "El socio es obligatorio")]
        public int IdSocio { get; set; }
        [ValidateNever]
        public Socio Socio { get; set; }
        
        [ValidateNever]
        public List<SelectListItem> SociosPosibles { get; set; }

        [ForeignKey("Rutina")]
        [Required(ErrorMessage = "La rutina es obligatorio")]
        public int IdRutina { get; set; }
        [ValidateNever]
        public Rutina Rutina { get; set; }
        
        [ValidateNever]
        public List<SelectListItem> RutinasPosibles { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "La fecha final es obligatoria")]
        public DateTime FechaFin { get; set; } = DateTime.Now;
        public int Calificacion { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Obligatorio2.Models
{
    public class Socio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdSocio { get; set;}
        public string Nombre { get; set;}
        [Required(ErrorMessage = "El tipo es obligatorio")]
        [RegularExpression("estandar|premium", ErrorMessage = "El tipo debe ser 'estándar' o 'premium'")]
        public string Tipo { get; set; }
        public string Telefono { get; set; }
        public string Mail {  get; set; }
        [ForeignKey("Local")]
        [Required(ErrorMessage ="Obligatorio agregar un local")]
        public int IdLocal { get; set; }
        [ValidateNever]
        public Local Local {  get; set; }
        [ValidateNever]
        public List<SelectListItem> LocalesPosibles { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Obligatorio2.Models
{
    public class Ejercicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdEjercicio { get; set; }
        [ForeignKey("TipoMaquina")]
        [Required(ErrorMessage = "Obligatorio agregar un tipo de máquina")]
        public int IdTipoMaq { get; set; }
        [ValidateNever]
        public TipoMaquina TipoMaquina  { get; set; }
        [ValidateNever]
        public List<SelectListItem> TipoMaqsPosibles { get; set; }
        public string Descripcion { get; set; }
    }
}

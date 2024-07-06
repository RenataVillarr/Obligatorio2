using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Obligatorio2.Models
{
    public class Maquina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdMaq { get; set; }
        [ForeignKey("Local")]
        [Required(ErrorMessage = "Obligatorio agregar un local")]
        public int IdLocal { get; set; }
        [ValidateNever]
        public Local Local { get; set; }
        [ValidateNever]
        public List<SelectListItem> LocalesPosibles { get; set; }
        public DateTime FechaCompra { get; set; } = DateTime.Now;
        public double PrecioCompra { get; set; }
        public int VidaUtil {  get; set; }
        [ForeignKey("TipoMaquina")]
        [Required(ErrorMessage = "Obligatorio agregar un tipo de maquina")]
        public int IdTipoMaq { get; set; }
        [ValidateNever]
        public TipoMaquina TipoMaquina { get; set; }
        [ValidateNever]
        public List<SelectListItem> TipoMaqsPosibles { get; set; }
        public string Disponible {  get; set; }

    }
}

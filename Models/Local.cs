using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Obligatorio2.Models
{
    public class Local
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdLocal { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NomRespon {  get; set; }
        public string TeleRespon { get; set; }
    }
}

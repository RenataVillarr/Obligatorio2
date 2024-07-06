using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio2.Models
{
    public class Rutina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRutina { get; set; }
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El tipo es obligatorio")]
        [RegularExpression("salud|competicionamateur|competicionprofesional", ErrorMessage = "El tipo debe ser 'Salud', 'Competición amateur' o 'Competición profesional'")]
        public string TipoRutina { get; set; }
        public int CalifRutinaPromedio { get; set; }
        public void ActualizarPromedioCalificacion(List<SocioRutina> sociorutinas)
        {
            if (sociorutinas == null || sociorutinas.Count == 0)
            {
                CalifRutinaPromedio = 0;
            }
            else
            {
                CalifRutinaPromedio = (int)sociorutinas.Average(sr => sr.Calificacion);
            }

        }
    }
}


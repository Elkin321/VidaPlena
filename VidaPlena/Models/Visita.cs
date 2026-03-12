using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("Visita")]
    public class Visita
    {
        [Key]
        public int idVisita { get; set; }

        [Required]
        [Display(Name = "Familiar")]
        public int idFamiliar { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public int idPaciente { get; set; }

        [Required]
        [Display(Name = "Fecha y Hora Programada")]
        public DateTime FechaHoraProg { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Programada";

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        // Navegación
        [ForeignKey("idFamiliar")]
        public Familiar? Familiar { get; set; }

        [ForeignKey("idPaciente")]
        public Paciente? Paciente { get; set; }
    }
}
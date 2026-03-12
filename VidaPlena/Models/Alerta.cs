using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("Alerta")]
    public class Alerta
    {
        [Key]
        public int idAlerta { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public int idPaciente { get; set; }

        [Display(Name = "Usuario")]
        public int? idUsuario { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tipo Alerta")]
        public string TipoAlerta { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Display(Name = "Nivel Prioridad")]
        public string NivelPrioridad { get; set; } = string.Empty;

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Generada";

        [Required]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; } = DateTime.Now;

        [Display(Name = "Fecha Resolución")]
        public DateTime? FechaResolucion { get; set; }

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        // Navegación
        [ForeignKey("idPaciente")]
        public Paciente? Paciente { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario? Usuario { get; set; }
    }
}
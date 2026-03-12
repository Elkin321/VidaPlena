using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("SignosVitales")]
    public class SignosVitales
    {
        [Key]
        public int idRegistro { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public int idPaciente { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }

        [StringLength(20)]
        [Display(Name = "Presión Arterial")]
        public string? PresionArterial { get; set; }

        [Display(Name = "Temperatura")]
        public decimal? Temperatura { get; set; }

        [Display(Name = "Frecuencia Cardíaca")]
        public int? FrecuenciaCardiaca { get; set; }

        [Display(Name = "Frecuencia Respiratoria")]
        public int? FrecuenciaRespiratoria { get; set; }

        [Display(Name = "Saturación Oxígeno")]
        public decimal? SaturacionOxigeno { get; set; }

        [Display(Name = "Peso")]
        public decimal? Peso { get; set; }

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        [Required]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; } = DateTime.Now;

        // Navegación
        [ForeignKey("idPaciente")]
        public Paciente? Paciente { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario? Usuario { get; set; }
    }
}

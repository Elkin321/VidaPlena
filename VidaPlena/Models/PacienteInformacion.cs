using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("PacienteInformacion")]
    public class PacienteInformacion
    {
        [Key]
        public int idInformacion { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public int idPaciente { get; set; }

        [StringLength(100)]
        [Display(Name = "EPS")]
        public string? Eps { get; set; }

        [Display(Name = "Alimentación")]
        public string? Alimentacion { get; set; }

        [Display(Name = "Complemento")]
        public string? Complemento { get; set; }

        [Display(Name = "Medicación")]
        public string? Medicacion { get; set; }

        [Display(Name = "Alergias")]
        public string? Alergias { get; set; }

        [Display(Name = "Antecedentes")]
        public string? Antecedentes { get; set; }

        [Display(Name = "Diagnósticos")]
        public string? Diagnosticos { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        [Display(Name = "Fecha Actualización")]
        public DateTime? FechaActualizacion { get; set; }

        // Navegación
        [ForeignKey("idPaciente")]
        public Paciente? Paciente { get; set; }
    }
}
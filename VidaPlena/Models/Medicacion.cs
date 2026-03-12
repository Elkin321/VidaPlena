using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("Medicacion")]
    public class Medicacion
    {
        [Key]
        public int idMedicacion { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public int idPaciente { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Medicamento")]
        public string NombreMedicamento { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Dosis")]
        public string Dosis { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Frecuencia")]
        public string Frecuencia { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Vía Administración")]
        public string? ViaAdministracion { get; set; }

        [Display(Name = "Hora Programada")]
        public TimeSpan? HoraProgramada { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string EstadoAdmin { get; set; } = "Pendiente";

        [Display(Name = "Efectos Adversos")]
        public string? EfectosAdversos { get; set; }

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
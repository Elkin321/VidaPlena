using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("Familiar")]
    public class Familiar
    {
        [Key]
        public int idFamiliar { get; set; }

        [Required]
        [Display(Name = "Paciente")]
        public int idPaciente { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Parentesco")]
        public string Parentesco { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Activo")]
        public bool? Activo { get; set; } = true;

        [Display(Name = "Fecha Creación")]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        // Navegación
        [ForeignKey("idPaciente")]
        public Paciente? Paciente { get; set; }

        public ICollection<Visita>? Visitas { get; set; }
    }
}
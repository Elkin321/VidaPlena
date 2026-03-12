using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        [Display(Name = "Hogar")]
        public int idHogar { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(10)]
        [Display(Name = "Género")]
        public string Genero { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        [Display(Name = "Rol")]
        public string Rol { get; set; } = string.Empty;

        [Display(Name = "Activo")]
        public bool? Activo { get; set; } = true;

        [Display(Name = "Fecha Creación")]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        // Navegación
        [ForeignKey("idHogar")]
        public Hogar? Hogar { get; set; }

        public ICollection<Paciente>? Pacientes { get; set; }
        public ICollection<Turno>? Turnos { get; set; }
        public ICollection<SignosVitales>? SignosVitales { get; set; }
        public ICollection<Medicacion>? Medicaciones { get; set; }
        public ICollection<Alerta>? Alertas { get; set; }
    }
}

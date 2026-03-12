using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("Hogar")]
    public class Hogar
    {
        [Key]
        public int idHogar { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Capacidad")]
        public int Capacidad { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        // Navegación
        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<Paciente>? Pacientes { get; set; }
        public ICollection<Turno>? Turnos { get; set; }
    }
}
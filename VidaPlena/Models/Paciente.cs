using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        public int idPaciente { get; set; }

        [Required]
        [Display(Name = "Hogar")]
        public int idHogar { get; set; }

        [Display(Name = "Cuidador Asignado")]
        public int? idUsuario { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Género")]
        public string Genero { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "EPS")]
        public string? Eps { get; set; }

        [StringLength(5)]
        [Display(Name = "Grupo Sanguíneo")]
        public string? GrupoSanguineo { get; set; }

        [Required]
        [Display(Name = "Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado Salud")]
        public string EstadoSalud { get; set; } = "Estable";

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Activo";

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        // Navegación
        [ForeignKey("idHogar")]
        public Hogar? Hogar { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario? Usuario { get; set; }

        public ICollection<PacienteInformacion>? PacientesInformacion { get; set; }
        public ICollection<SignosVitales>? SignosVitales { get; set; }
        public ICollection<Medicacion>? Medicaciones { get; set; }
        public ICollection<Alerta>? Alertas { get; set; }
        public ICollection<Familiar>? Familiares { get; set; }
        public ICollection<Visita>? Visitas { get; set; }
    }
}
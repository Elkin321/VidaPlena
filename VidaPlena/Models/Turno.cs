using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VidaPlena.Models
{
    [Table("Turno")]
    public class Turno
    {
        [Key]
        public int idTurno { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int idUsuario { get; set; }

        [Required]
        [Display(Name = "Hogar")]
        public int idHogar { get; set; }

        [Required]
        [Display(Name = "Hora Inicio")]
        public DateTime HoraInicio { get; set; }

        [Required]
        [Display(Name = "Hora Fin")]
        public DateTime HoraFin { get; set; }

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        [Display(Name = "Fecha Creación")]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

        // Navegación
        [ForeignKey("idUsuario")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("idHogar")]
        public Hogar? Hogar { get; set; }
    }
}
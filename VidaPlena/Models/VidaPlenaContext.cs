using Microsoft.EntityFrameworkCore;

namespace VidaPlena.Models
{
    public class VidaPlenaContext : DbContext
    {
        public VidaPlenaContext(DbContextOptions<VidaPlenaContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Hogar> Hogar { get; set; }
        public DbSet<Familiar> Familiar { get; set; }
        public DbSet<Medicacion> Medicacion { get; set; }
        public DbSet<SignosVitales> SignosVitales { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<Visita> Visita { get; set; }
        public DbSet<Alerta> Alerta { get; set; }
        public DbSet<PacienteInformacion> PacienteInformacion { get; set; }
    }
}
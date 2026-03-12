using Microsoft.AspNetCore.Mvc;
using VidaPlena.Models;
using Microsoft.EntityFrameworkCore;

namespace VidaPlena.Controllers
{
    public class PacientesController : Controller
    {
        private readonly VidaPlenaContext _context;

        public PacientesController(VidaPlenaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var pacientes = _context.Paciente.ToList();
            return View(pacientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                paciente.FechaCreacion = DateTime.Now;
                _context.Paciente.Add(paciente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var paciente = _context.Paciente.FirstOrDefault(p => p.idPaciente == id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Paciente.Update(paciente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var paciente = _context.Paciente.FirstOrDefault(p => p.idPaciente == id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var paciente = _context.Paciente.Find(id);
            if (paciente != null)
            {
                _context.Paciente.Remove(paciente);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetStats()
        {
            try
            {
                var pacientes = _context.Paciente
                    .Where(p => p.Estado == "Activo")
                    .Count();

                var alertas = _context.Alerta
                    .Where(a => a.Estado == "Generada" || a.Estado == "Notificada")
                    .Count();

                var usuarios = _context.Usuario
                    .Where(u => u.Activo == true)
                    .Count();

                var visitas = _context.Visita
                    .Where(v => v.FechaHoraProg.Date == DateTime.Today)
                    .Count();

                var listaPacientes = _context.Paciente
                    .OrderByDescending(p => p.FechaCreacion)
                    .Take(5)
                    .Select(p => new {
                        p.Nombre,
                        p.Apellido,
                        p.Eps,
                        p.EstadoSalud,
                        p.Estado
                    }).ToList();

                var listaAlertas = _context.Alerta
                    .OrderByDescending(a => a.FechaHora)
                    .Take(5)
                    .Select(a => new {
                        a.TipoAlerta,
                        a.NivelPrioridad,
                        a.Estado
                    }).ToList();

                return Json(new
                {
                    pacientes,
                    alertas,
                    usuarios,
                    visitas,
                    listaPacientes,
                    listaAlertas
                });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using VidaPlena.Models;
using Microsoft.EntityFrameworkCore;

namespace VidaPlena.Controllers
{
    public class HistoriaController : Controller
    {
        private readonly VidaPlenaContext _context;

        public HistoriaController(VidaPlenaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var paciente = _context.Paciente
                .Include(p => p.PacientesInformacion)
                .FirstOrDefault(p => p.idPaciente == id);

            if (paciente == null) return NotFound();

            var rol = HttpContext.Session.GetString("UsuarioRol");
            ViewBag.Rol = rol;
            ViewBag.PuedeEditar = (rol == "Medico" || rol == "Administrador");

            return View(paciente);
        }

        [HttpGet]
        public IActionResult Agregar(int id)
        {
            var rol = HttpContext.Session.GetString("UsuarioRol");
            if (rol != "Medico" && rol != "Administrador")
                return RedirectToAction("Index", new { id });

            var paciente = _context.Paciente.FirstOrDefault(p => p.idPaciente == id);
            if (paciente == null) return NotFound();

            ViewBag.Paciente = paciente;
            var info = new PacienteInformacion { idPaciente = id };
            return View(info);
        }

        [HttpPost]
        public IActionResult Agregar(PacienteInformacion info)
        {
            var rol = HttpContext.Session.GetString("UsuarioRol");
            if (rol != "Medico" && rol != "Administrador")
                return Unauthorized();

            if (ModelState.IsValid)
            {
                info.FechaCreacion = DateTime.Now;
                info.FechaActualizacion = DateTime.Now;
                _context.PacienteInformacion.Add(info);
                _context.SaveChanges();
                return RedirectToAction("Index", new { id = info.idPaciente });
            }
            return View(info);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using VidaPlena.Models;

namespace VidaPlena.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly VidaPlenaContext _context;

        public UsuariosController(VidaPlenaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarios = _context.Usuario.ToList();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.FechaCreacion = DateTime.Now;
                usuario.Activo = true;
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var usuario = _context.Usuario.FirstOrDefault(u => u.idUsuario == id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var usuario = _context.Usuario.FirstOrDefault(u => u.idUsuario == id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var usuario = _context.Usuario.Find(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
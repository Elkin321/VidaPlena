using Microsoft.AspNetCore.Mvc;
using VidaPlena.Models;

namespace VidaPlena.Controllers
{
    public class AccountController : Controller
    {
        private readonly VidaPlenaContext _context;

        public AccountController(VidaPlenaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string contrasena, string rol)
        {
            var usuario = _context.Usuario
                .FirstOrDefault(u => u.Email == email
                                  && u.Contrasena == contrasena
                                  && u.Rol == rol
                                  && u.Activo == true);

            if (usuario != null)
            {
                HttpContext.Session.SetString("UsuarioId", usuario.idUsuario.ToString());
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre + " " + usuario.Apellido);
                HttpContext.Session.SetString("UsuarioRol", usuario.Rol);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Credenciales incorrectas. Verifica tu email, contraseña y rol.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
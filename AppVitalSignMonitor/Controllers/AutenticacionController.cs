using AppVitalSignMonitor.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppVitalSignMonitor.Controllers
{
    public class AutenticacionController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] // Las autenticaciones siempre deberian realizarse por Post.
        public async Task<IActionResult> Login([Bind("NombreUsuario, Contrasena")]Usuario usuario) // Con el "Bind" nos aseguramos que se pasen solo los datos que van entre parentesis.
        {
            // Login
            Usuario usuEncontrado = new UsuarioServices().BuscarUsuario(usuario.NombreUsuario, usuario.Contrasena); 
            if (usuario != null)
            {
                var claims = new List<Claim> // Aqui se crearia la cookie (generacion de informacion)
                {
                    new Claim(ClaimTypes.Name, usuEncontrado.NombreUsuario), // Datos que queremos que esten en la cookie.
                    new Claim(ClaimTypes.Role, usuEncontrado.Rol)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home"); 
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Autenticacion");
        }
    }
}

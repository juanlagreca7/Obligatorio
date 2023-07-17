using AppVitalSignMonitor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppVitalSignMonitor.Controllers
{
    [Authorize] // Restringe el acceso al controlador.
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Usuario()
        {
            return View();
        }

        [Authorize(Roles="Administrador")] // Se utiliza el "Authorize" para restringir el acceso a ciertos usuarios.
        public IActionResult Dispositivo()
        {
            return View();
        }
    }
}
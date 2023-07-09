using APP_ArqComputadorasV2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace APP_ArqComputadorasV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.IsLoginPage = true;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                ViewBag.Message = "Inicio de sesión exitoso.";
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Message = "Nombre de usuario o contraseña incorrectos.";
                return RedirectToAction("Login");
            }


        }

        //hasta aqui
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
        public IActionResult Contact()
        {
            ViewBag.Message = "Team";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
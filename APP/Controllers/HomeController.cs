using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP_ArqComputadorasUPC.Controllers
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
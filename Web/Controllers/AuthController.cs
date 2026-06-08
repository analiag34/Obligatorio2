using Dominio;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        Sistema s = Sistema.Instance();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel lvm)
        {
            Persona buscada = s.VerificarExistencia(lvm.Email, lvm.Password);
            if (buscada is null)
            {
                ViewBag.msg = "Credenciales incorrectas";
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("LogueadoId", buscada.id);
                HttpContext.Session.SetString("LogueadoNombre", buscada.Nombre);
                HttpContext.Session.SetString("LogueadoRol", buscada.Rol);
                return RedirectToAction("Index", "Home"); 

            }

          
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}

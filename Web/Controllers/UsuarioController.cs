using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        Sistema s = Sistema.Instance();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Persona nueva)
        {
            try
            {
                s.AltaPersona(nueva);
                ViewBag.msg = "Alta correcta";
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();

        }
    }
}

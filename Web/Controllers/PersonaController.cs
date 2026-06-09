using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class PersonaController : Controller
    {
        Sistema s = Sistema.Instance();


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        ///TODO Alta persona o alta cuenta si la persona existe??
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


        public IActionResult VerPerfil()
        {
            int lid = (int)HttpContext.Session.GetInt32("LogueadoId");
            ViewBag.Cuentas = s.ObtenerCuentasPorIdPersona(lid);
            Persona p = s.ObtenerPersonaPorId(lid);
            return View(p);

        }
    }
}

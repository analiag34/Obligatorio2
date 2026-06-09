using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ActivoController : Controller
    {
        Sistema s = Sistema.Instance();
        public IActionResult Index()
        {
            int lid = (int)HttpContext.Session.GetInt32("LogueadoId");
            Persona p = s.ObtenerPersonaPorId(lid);
            List<Activo> listaActivos = s.ObtenerActivosPorPersona(p);
            return View(listaActivos);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel lvm)
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebApiInAsp.netcoreMvcDemo.Controllers
{
    public class AuthenticationUIController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveSession(string username)
        {
            HttpContext.Session.SetString("username", username);
            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}

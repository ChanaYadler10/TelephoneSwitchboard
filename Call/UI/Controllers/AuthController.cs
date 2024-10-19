using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models;

namespace UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // שמירת שם המשתמש והסיסמה ב-Session
                HttpContext.Session.SetString("Username", model.Username);
                HttpContext.Session.SetString("Password", model.Password);

                return RedirectToAction("Index", "TelephoneExtension");
            }

            return View(model);
        }
    }
}

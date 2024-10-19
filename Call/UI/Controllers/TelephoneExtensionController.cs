using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Central_Phone.Interfaces;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class TelephoneExtensionController : Controller
    {
        private readonly ITelephoneExtensionService _telephoneExtensionService;
        private readonly ILogger<TelephoneExtensionController> _logger;

        public TelephoneExtensionController(ITelephoneExtensionService telephoneExtensionService, ILogger<TelephoneExtensionController> logger)
        {
            _telephoneExtensionService = telephoneExtensionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("Username");
            var password = HttpContext.Session.GetString("Password");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login", "Auth");
            }

            var result = await _telephoneExtensionService.GetTelephoneLines(username, password);
            return View(result.Data);
        }

        // שאר הפונקציות נשארות כפי שהן
    }
}

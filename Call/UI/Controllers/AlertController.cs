using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Central_Phone.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class AlertController : Controller
    {
        private readonly ITelephoneExtensionService _telephoneExtensionService;
        private readonly ILogger<AlertController> _logger;

        public AlertController(ITelephoneExtensionService telephoneExtensionService, ILogger<AlertController> logger)
        {
            _telephoneExtensionService = telephoneExtensionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var username = "your_username"; // הכנס כאן את שם המשתמש האמיתי
            var password = "your_password"; // הכנס כאן את הסיסמא האמיתית

            try
            {
                var result = await _telephoneExtensionService.GetAllTelephoneLines(username, password);
                var alerts = new List<AlertViewModel>();

                foreach (var line in result.Data)
                {
                    if (line.alert_locked == "true")
                    {
                        alerts.Add(new AlertViewModel
                        {
                            AlertType = "Locked",
                            Message = $"The line {line.name} is locked.",
                            Timestamp = DateTime.Now,
                            Resolved = false
                        });
                    }
                    // הוספת לוגיקה נוספת לבדיקת סטטוסים נוספים והוספת התרעות לרשימה
                }

                return View(alerts);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error retrieving telephone lines");
                ModelState.AddModelError(string.Empty, "Error retrieving telephone lines: " + ex.Message);
                return View(new List<AlertViewModel>());
            }
        }
    }
}

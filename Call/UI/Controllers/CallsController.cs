using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml; // לשימוש ב-EPPlus
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace UI.Controllers
{
    public class CallsController : Controller
    {
        private readonly ICallHistoryService _callHistoryService;
        private readonly ILogger<CallsController> _logger;

        public CallsController(ICallHistoryService callHistoryService, ILogger<CallsController> logger)
        {
            _callHistoryService = callHistoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm = "", string filterStatus = "")
        {
            _logger.LogInformation("Entering CallsController Index action.");
            try
            {
                var callHistoryResponse = await _callHistoryService.GetArrayFieldsOfCompletedCallsAsync(DateTime.Now.AddDays(-30), DateTime.Now);

                var model = new CallsViewModel
                {
                    CallHistory = callHistoryResponse.Data,
                    SearchTerm = searchTerm,
                    FilterStatus = filterStatus
                };

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    model.CallHistory = model.CallHistory
                        .Where(c => c.callerid_external.Contains(searchTerm) || c.dnumber.Contains(searchTerm));
                }

                if (!string.IsNullOrEmpty(filterStatus))
                {
                    model.CallHistory = model.CallHistory
                        .Where(c => c.status.Equals(filterStatus, StringComparison.OrdinalIgnoreCase));
                }

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving call history.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExportToExcel()
        {
            try
            {
                _logger.LogInformation("Starting export to Excel.");

                var callHistoryResponse = await _callHistoryService.GetArrayFieldsOfCompletedCallsAsync(DateTime.Now.AddDays(-30), DateTime.Now);
                if (callHistoryResponse == null)
                {
                    _logger.LogError("Call history response is null.");
                    return StatusCode(500, "Call history response is null.");
                }

                var callHistory = callHistoryResponse.Data;
                if (callHistory == null)
                {
                    _logger.LogError("Call history data is null.");
                    return StatusCode(500, "Call history data is null.");
                }

                _logger.LogInformation($"Retrieved {callHistory.Count()} records.");

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("CallHistory");

                    worksheet.Cells[1, 1].Value = "זמן";
                    worksheet.Cells[1, 2].Value = "מספר מתקשר";
                    worksheet.Cells[1, 3].Value = "יעד";
                    worksheet.Cells[1, 4].Value = "משך";
                    worksheet.Cells[1, 5].Value = "סטטוס";
                    worksheet.Cells[1, 6].Value = "הקלטה";

                    for (int i = 0; i < callHistory.Count(); i++)
                    {
                        var call = callHistory.ElementAt(i);
                        worksheet.Cells[i + 2, 1].Value = call.start;
                        worksheet.Cells[i + 2, 2].Value = call.callerid_external;
                        worksheet.Cells[i + 2, 3].Value = call.dnumber;
                        worksheet.Cells[i + 2, 4].Value = call.totaltime;
                        worksheet.Cells[i + 2, 5].Value = call.status;
                        worksheet.Cells[i + 2, 6].Value = call.recording;
                    }

                    var stream = new MemoryStream();
                    package.SaveAs(stream);
                    stream.Position = 0;
                    var fileName = "CallHistory.xlsx";
                    _logger.LogInformation("Export to Excel completed successfully.");
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while exporting to Excel.");
                return StatusCode(500, "Internal server error");
            }
        }
    }

    public class CallsViewModel
    {
        public IEnumerable<GetCallHistory> CallHistory { get; set; }
        public string SearchTerm { get; set; }
        public string FilterStatus { get; set; }
    }
}

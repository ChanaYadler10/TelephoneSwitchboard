using Microsoft.AspNetCore.Mvc;
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IActivecall _activecallService;
        private readonly ICallHistoryService _callHistoryService;

        public DashboardController(IActivecall activecallService, ICallHistoryService callHistoryService)
        {
            _activecallService = activecallService;
            _callHistoryService = callHistoryService;
        }

        public async Task<IActionResult> Index()
        {
            var activeCallsResponse = await _activecallService.GetActiveCallsAsync();
            var callHistoryResponse = await _callHistoryService.GetArrayFieldsOfCompletedCallsAsync(DateTime.Now.AddDays(-30), DateTime.Now);

            var model = new DashboardViewModel
            {
                ActiveCalls = activeCallsResponse.Data,
                CallHistory = callHistoryResponse.Data
            };

            return View(model);
        }
    }

    public class DashboardViewModel
    {
        public IEnumerable<Activecall> ActiveCalls { get; set; }
        public IEnumerable<GetCallHistory> CallHistory { get; set; }
    }
}

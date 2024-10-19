
    using global::Service.Central_Phone.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Service.Central_Phone.Interfaces;
    using System;
    using System.Threading.Tasks;

    namespace UI.Controllers

    {
        
        public class CallHistoryController : ControllerBase
        {
            private readonly ICallHistoryService _callHistoryService;

            public CallHistoryController(ICallHistoryService callHistoryService)
            {
                _callHistoryService = callHistoryService;
            }

        [HttpGet("completed-call/{uniqueid}")]
        public async Task<IActionResult> GetFieldOfCompletedCall(string uniqueid)
        {
            if (string.IsNullOrWhiteSpace(uniqueid))
            {
                return BadRequest("Unique ID is required.");
            }

            var result = await _callHistoryService.GetFieldOfCompletedCallAsync(uniqueid);

            if (result == null)
            {
                return NotFound("Completed call not found.");
            }

            return Ok(result);
        }


        [HttpGet("completed-calls")]
        public async Task<IActionResult> GetArrayFieldsOfCompletedCalls(DateTime start, DateTime end)
        {
            if (start == default || end == default || start >= end)
            {
                return BadRequest("Invalid date range.");
            }

            var result = await _callHistoryService.GetArrayFieldsOfCompletedCallsAsync(start, end);

            if (result == null || result.Data == null || !result.Data.Any())
            {
                return NotFound("No completed calls found in the specified date range.");
            }

            return Ok(result);
        }








    }
}



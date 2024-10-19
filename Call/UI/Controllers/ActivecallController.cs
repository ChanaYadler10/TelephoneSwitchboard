
    using global::Service.Central_Phone.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Service.Central_Phone.Interfaces;
    using System.Threading.Tasks;

namespace UI.Controllers
{
    
        public class ActivecallController : ControllerBase
        {
            private readonly IActivecall _activecallService;

            public ActivecallController(IActivecall activecallService)
            {
                _activecallService = activecallService;
            }

            [HttpGet("GetActiveCalls")]
            public async Task<IActionResult> GetActiveCallsAsync()
            {
                var result = await _activecallService.GetActiveCallsAsync();
                return Ok(result);
            }

            [HttpPost("MakeCall")]
            public async Task<IActionResult> MakeCallAsync(
                [FromQuery] string stype,
                [FromQuery] string snumber,
                [FromQuery] string ctype,
                [FromQuery] string cnumber,
                [FromQuery] int? wait)
            {
                var result = await _activecallService.MakeCallAsync(stype, snumber, ctype, cnumber, wait);
                return Ok(result);
            }
        }
    }


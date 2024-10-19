    using Microsoft.AspNetCore.Mvc;
    using Service.Central_Phone.Interfaces;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
using System.Text.Json;
namespace UI.Controllers
{
        
        public class IVRController : ControllerBase
        {
            private readonly IIvrService _ivrService;

            public IVRController(IIvrService ivrService)
            {
                _ivrService = ivrService;
            }

        [HttpGet("list")]
        public async Task<IActionResult> GetIvrList()
        {
            try
            {
                var ivrList = await _ivrService.GetIvrListAsync();
                return Ok(ivrList);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if necessary
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpGet("destination")]
            public async Task<IActionResult> GetIvrDestination(int ivr, string name)
            {
                try
                {
                    if (ivr <= 0 || string.IsNullOrEmpty(name))
                        return BadRequest("Invalid IVR or name");

                    var ivrDestination = await _ivrService.GetIvrDestinationAsync(ivr, name);
                    return Ok(ivrDestination);
                }
                catch (ArgumentException ex)
                {
                    // Log the exception (ex) if necessary
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    // Log the exception (ex) if necessary
                    return StatusCode(500, "Internal server error");
                }
            }
        }
    }

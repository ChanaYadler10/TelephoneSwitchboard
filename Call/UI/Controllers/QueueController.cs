using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Central_Phone.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace UI.Controllers
{
   
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _queueService;
        private readonly ILogger<QueueController> _logger;

        public QueueController(IQueueService queueService, ILogger<QueueController> logger)
        {
            _queueService = queueService;
            _logger = logger;
        }

        [HttpGet("queues")]
        public async Task<IActionResult> GetQueues()
        {
            try
            {
                var queues = await _queueService.GetQueuesAsync();
                return Ok(queues);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving queues");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("queues/{id}")]
        public async Task<IActionResult> GetQueueDetails(int id)
        {
            try
            {
                var queueDetails = await _queueService.GetQueueDetailsAsync(id);
                if (queueDetails.ToString()==null  )
                {
                    return NotFound("Queue not found");
                }

                return Ok(queueDetails);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Invalid queue ID");
                return BadRequest("Invalid queue ID");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving queue details");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

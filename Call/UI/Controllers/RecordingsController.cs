using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Models;

namespace UI.Controllers
{
    public class RecordingsController : Controller
    {
        private readonly IRetrievingRecordingService _retrievingRecordingService;

        public RecordingsController(IRetrievingRecordingService retrievingRecordingService)
        {
            _retrievingRecordingService = retrievingRecordingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var end = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            var start = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeSeconds().ToString();
            var recordGroup = "";
            Console.WriteLine($"Requesting index page with default recordings: Start={start}, End={end}");

            var result = await _retrievingRecordingService.GetAllRecordingsAsync(recordGroup, start, end);
            if (result.Responses.Any(r => r.Code == 200))
            {
                return View(result.Data);
            }
            return StatusCode(result.Responses.First().Code, result);
        }

        [HttpGet("GetCallRecording")]
        public async Task<IActionResult> GetCallRecording(string recordGroup, string uniqueId, string recordId)
        {
            Console.WriteLine($"Requesting call recording: RecordGroup={recordGroup}, UniqueId={uniqueId}, RecordId={recordId}");
            var result = await _retrievingRecordingService.GetCallRecordingAsync(recordGroup, uniqueId, recordId);

            if (result.Responses.Any(r => r.Code == 200))
            {
                var recording = result.Data.FirstOrDefault();
                if (recording != null && recording.AudioData != null) // הנח שהשדה הנכון הוא AudioData
                {
                    return File(recording.AudioData, "audio/mpeg");
                }
            }

            return StatusCode(result.Responses.First().Code, result);
        }

        [HttpGet("GetAllRecordings")]
        public async Task<IActionResult> GetAllRecordings(string recordGroup, string start, string end)
        {
            Console.WriteLine($"Requesting all recordings: RecordGroup={recordGroup}, Start={start}, End={end}");
            var result = await _retrievingRecordingService.GetAllRecordingsAsync(recordGroup, start, end);
            if (result.Responses.Any(r => r.Code == 200))
            {
                return Ok(result.Data);
            }
            return StatusCode(result.Responses.First().Code, result);
        }

        [HttpGet("GetAllRecordingsDefault")]
        public async Task<IActionResult> GetAllRecordingsDefault()
        {
            var end = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            var start = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeSeconds().ToString();
            var recordGroup = "";
            Console.WriteLine($"Requesting default recordings: Start={start}, End={end}");

            var result = await _retrievingRecordingService.GetAllRecordingsAsync(recordGroup, start, end);
            if (result.Responses.Any(r => r.Code == 200))
            {
                return Ok(result.Data);
            }
            return StatusCode(result.Responses.First().Code, result);
        }

        [HttpPost("DownloadAndConvertRecording")]
        public async Task<IActionResult> DownloadAndConvertRecording(string recordGroup, string uniqueId, string recordId, string outputFilePath)
        {
            Console.WriteLine($"Requesting to download and convert recording: RecordGroup={recordGroup}, UniqueId={uniqueId}, RecordId={recordId}, OutputFilePath={outputFilePath}");
            var success = await _retrievingRecordingService.DownloadAndConvertRecordingAsync(recordGroup, uniqueId, recordId, outputFilePath);
            if (success)
            {
                return Ok("Recording downloaded and converted successfully.");
            }
            return StatusCode(500, "Failed to download and convert recording.");
        }
    }
}

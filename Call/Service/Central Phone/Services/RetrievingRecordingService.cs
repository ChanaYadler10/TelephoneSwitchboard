using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using NAudio.Lame;
using NAudio.Wave;
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.Central_Phone.Services
{
    public class RetrievingRecordingService : BaseApiService, IRetrievingRecordingService
    {
        private readonly ILogger<RetrievingRecordingService> _logger;

        public RetrievingRecordingService(HttpClient client, IOptions<APISettings> apiSettings, ILogger<RetrievingRecordingService> logger)
            : base(client, apiSettings)
        {
            _logger = logger;
        }

        public async Task<ApiResponse<RetrievingRecording>> GetCallRecordingAsync(string recordGroup, string uniqueId, string recordId)
        {
            var requestUri = string.Empty;
            try
            {
                var queryParams = new Dictionary<string, string>
        {
            { "recordgroup", recordGroup },
            { "uniqueid", uniqueId },
            { "recordid", recordId }
        };
                requestUri = new UriBuilder($"{_apiSettings.BaseUrl}{_apiSettings.Endpoints["GetRecording"]}").Uri.ToString();
                _logger.LogInformation("Requesting URL: {RequestUri} with params: {Params}", requestUri, queryParams);

                var response = await GetAsync<RetrievingRecording>(_apiSettings.Endpoints["GetRecording"], queryParams);

                if (response.Data != null && response.Data.Any())
                {
                    var recording = response.Data.First();
                    if (!string.IsNullOrEmpty(recording.data))
                    {
                        recording.AudioData = Convert.FromBase64String(recording.data);
                    }
                }

                _logger.LogInformation("Received response: {Response}", response.ToString());

                return new ApiResponse<RetrievingRecording>
                {
                    Data = response.Data,
                    Responses = response.Responses
                };
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP Request failed for URL: {RequestUri}", requestUri);
                return new ApiResponse<RetrievingRecording>
                {
                    Responses = new List<ResponseInfo> { new ResponseInfo { Code = 500, Message = $"Internal server error: {ex.Message}" } }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving call recording for URL: {RequestUri}", requestUri);
                return new ApiResponse<RetrievingRecording>
                {
                    Responses = new List<ResponseInfo> { new ResponseInfo { Code = 500, Message = $"Internal server error: {ex.Message}" } }
                };
            }
        }

        public async Task<ApiResponse<RetrievingRecording>> GetAllRecordingsAsync(string recordGroup, string start, string end)
        {
            var requestUri = string.Empty;
            try
            {
                var queryParams = new Dictionary<string, string>
                {
                { "auth_username", "online.kenion" },
                { "auth_password", "thAd1ifApozir0s" },
                { "recordgroup", recordGroup },
                { "start", start },
                { "end", end }
            };
                requestUri = new UriBuilder($"{_apiSettings.BaseUrl}{_apiSettings.Endpoints["RecordingList"]}").Uri.ToString();
                _logger.LogInformation("Requesting URL: {RequestUri} with params: {Params}", requestUri, queryParams);

                var response = await GetAsync<RetrievingRecording>(_apiSettings.Endpoints["RecordingList"], queryParams);

                _logger.LogInformation("Received response: {Response}", response.ToString());

                return new ApiResponse<RetrievingRecording>
                {
                    Data = response.Data,
                    Responses = response.Responses
                };
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP Request failed for URL: {RequestUri}", requestUri);
                return new ApiResponse<RetrievingRecording>
                {
                    Responses = new List<ResponseInfo> { new ResponseInfo { Code = 500, Message = $"Internal server error: {ex.Message}" } }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all recordings for URL: {RequestUri}", requestUri);
                return new ApiResponse<RetrievingRecording>
                {
                    Responses = new List<ResponseInfo> { new ResponseInfo { Code = 500, Message = $"Internal server error: {ex.Message}" } }
                };
            }
        }

        public async Task<bool> DownloadAndConvertRecordingAsync(string recordGroup, string uniqueId, string recordId, string outputFilePath)
        {
            var requestUri = string.Empty;
            try
            {
                var queryParams = new Dictionary<string, string>
        {
            { "recordgroup", recordGroup },
            { "uniqueid", uniqueId },
            { "recordid", recordId }
        };
                requestUri = new UriBuilder($"{_apiSettings.BaseUrl}{_apiSettings.Endpoints["GetRecording"]}").Uri.ToString();
                _logger.LogInformation("Requesting URL: {RequestUri} with params: {Params}", requestUri, queryParams);

                // For testing purposes, use a simpler output file path
                outputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.mp3");
                _logger.LogInformation("Output file path: {OutputFilePath}", outputFilePath);

                var response = await GetAsync<RetrievingRecording>(_apiSettings.Endpoints["GetRecording"], queryParams);
                _logger.LogInformation("Received response: {Response}", response.ToString());


                if (response == null || response.Data.First().data == null)
                {
                    _logger.LogError("base64_encoded_audio key not found in the response.");
                    return false;
                }

                var base64EncodedAudio = response.Data.First().data.ToString();
                if (string.IsNullOrEmpty(base64EncodedAudio))
                {
                    _logger.LogError("Failed to extract the base64 encoded audio from the response.");
                    return false;
                }

                byte[] audioBytes = Convert.FromBase64String(base64EncodedAudio);
                var tempWavFilePath = Path.Combine(Path.GetTempPath(), "temp.wav");
                _logger.LogInformation("Temporary WAV file path: {TempWavFilePath}", tempWavFilePath);

                using (var memoryStream = new MemoryStream(audioBytes))
                {
                    using (var waveFileWriter = new WaveFileWriter(tempWavFilePath, new WaveFormat(8000, 16, 1)))
                    {
                        waveFileWriter.Write(audioBytes, 0, audioBytes.Length);
                        _logger.LogInformation("WAV file written to: {TempWavFilePath}", tempWavFilePath);
                    }

                    if (File.Exists(tempWavFilePath))
                    {
                        _logger.LogInformation("Converting WAV to MP3...");
                        using (var waveReader = new WaveFileReader(tempWavFilePath))
                        using (var mp3File = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                        using (var writer = new LameMP3FileWriter(mp3File, waveReader.WaveFormat, LAMEPreset.VBR_90))
                        {
                            waveReader.CopyTo(writer);
                        }

                        if (File.Exists(outputFilePath))
                        {
                            _logger.LogInformation("MP3 file saved to: {OutputFilePath}", outputFilePath);

                            // Log files in the directory to confirm existence
                            var directoryPath = Path.GetDirectoryName(outputFilePath);
                            var files = Directory.GetFiles(directoryPath);
                            _logger.LogInformation("Files in the directory {DirectoryPath}: {Files}", directoryPath, string.Join(", ", files));

                            File.Delete(tempWavFilePath); // Clean up the temporary WAV file
                            return true;
                        }
                        else
                        {
                            _logger.LogError("Failed to save the MP3 recording.");
                        }
                    }
                    else
                    {
                        _logger.LogError("Failed to save the temporary WAV file.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error parsing JSON response for URL: {RequestUri}", requestUri);
                return false;
            }
            return false;
        }

        //public ApiResponse<RetrievingRecording> ExcludeBase64Audio(string jsonResponse)
        //{
        //    try
        //    {
        //        var jsonObject = JObject.Parse(jsonResponse);

        //        var retrievingRecording = new RetrievingRecording
        //        {
        //            RecordGroup = jsonObject["data"]?["recordGroup"]?.ToString(),
        //            UniqueId = jsonObject["data"]?["uniqueId"]?.ToString(),
        //            RecordId = jsonObject["data"]?["recordId"]?.ToString(),
        //            Base64Audio = jsonObject["data"]?["data"] != null ? "BASE64_AUDIO_CONTENT" : null
        //        };

        //        var result = new ApiResponse<RetrievingRecording>
        //        {
        //            Data = new List<RetrievingRecording> { retrievingRecording },
        //            Responses = jsonObject["responses"]?.ToObject<List<ResponseInfo>>()
        //        };

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error excluding base64 audio");
        //        return null; // או שתוכל להחזיר אובייקט ברירת מחדל
        //    }
        //}
        public string ExcludeBase64Audio(string jsonResponse)
        {
            try
            {
                var jsonObject = JObject.Parse(jsonResponse);

                if (jsonObject["data"]?["data"] != null)
                {
                    jsonObject["data"]["data"] = "BASE64_AUDIO_CONTENT";
                }

                return jsonObject.ToString();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error excluding base64 audio");
                return jsonResponse;
            }
        }


    }
}

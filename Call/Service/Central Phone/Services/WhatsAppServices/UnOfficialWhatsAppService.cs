using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Service.Central_Phone.Models;
using Service.WhatsAppModels;
using Twilio.TwiML.Messaging;



namespace Service.WhatsAppServices
    {
        public class UnOfficialWhatsAppService : IUnOfficialIWhatsAppService
    {
            private readonly APISettings _settings;
            private readonly ILogger<UnOfficialWhatsAppService> _logger;

            public UnOfficialWhatsAppService(IOptions<APISettings> options, ILogger<UnOfficialWhatsAppService> logger)
            {
                _settings = options.Value;
                _logger = logger;
            }

            public async Task SendMessageAsync(WhatsAppMessageRequest request)
            {


            using (var httpClient = new HttpClient())

                {
                    var payload = new
                    {
                        chatId = request.PhoneNumber,
                        message = request.Body
                    };


                    var content = new StringContent(
                        JsonConvert.SerializeObject(payload),
                        Encoding.UTF8,
                        "application/json");

                     httpClient.DefaultRequestHeaders.Clear();
                     httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.ApiTokenInstance);
                var requestUri = $"{_settings.ApiUrl}/waInstance{_settings.IdInstance}/sendMessage/{_settings.ApiTokenInstance}";

                _logger.LogInformation("Sending message to {PhoneNumber}", request.PhoneNumber);
                    _logger.LogInformation("Request payload: {Payload}", JsonConvert.SerializeObject(payload));

                    try
                    {
                    var response = await httpClient.PostAsync(requestUri, content);


                    _logger.LogInformation("Response status code: {StatusCode}", response.StatusCode);

                        var responseContent = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation("Response content: {ResponseContent}", responseContent);

                        if (!response.IsSuccessStatusCode)
                        {
                            _logger.LogError("Failed to send message. Status code: {StatusCode}, Response: {ResponseContent}", response.StatusCode, responseContent);
                            throw new HttpRequestException($"Failed to send message. Status code: {response.StatusCode}, Response: {responseContent}");
                        }

                        _logger.LogInformation("Message sent successfully to {chatId}", request.PhoneNumber);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred while sending message");
                        throw;
                    }
                }
            }
        }
    }






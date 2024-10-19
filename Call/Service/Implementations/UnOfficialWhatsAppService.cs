using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Repository.Interfaces;
using Repository.Models;
using Service.Central_Phone.Models;
using Service.Interfaces;
using Service.WhatsAppModels;
using Microsoft.EntityFrameworkCore;

namespace Service.Implementations
{
    public class UnOfficialWhatsAppService : IUnOfficialWhatsAppService
    {
        private readonly APISettings _settings;
        private readonly ILogger<UnOfficialWhatsAppService> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICommunicationRepository _communicationRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly IConversationStatusRepository _conversationStatusRepository;

        public UnOfficialWhatsAppService(
            IOptions<APISettings> options,
            ILogger<UnOfficialWhatsAppService> logger,
            ICustomerRepository customerRepository,
            ICommunicationRepository communicationRepository,
            IConversationRepository conversationRepository,
            IConversationStatusRepository conversationStatusRepository)
        {
            _settings = options.Value;
            _logger = logger;
            _customerRepository = customerRepository;
            _communicationRepository = communicationRepository;
            _conversationRepository = conversationRepository;
            _conversationStatusRepository = conversationStatusRepository;
        }

        public async System.Threading.Tasks.Task SendMessageAsync(WhatsAppMessageRequest request)
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

                    // Add communication and handle conversation
                    await AddCommunicationAndHandleConversationAsync(request.PhoneNumber, request.Body);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while sending message");
                    throw;
                }
            }
        }

        public async Task<Customer> CheckAndAddCustomerIfNotExistAsync(string phoneNumber)
        {
            var formattedPhoneNumber = FormatPhoneNumber(phoneNumber);

            var customer = await _customerRepository.GetCustomerWithPhoneAsync(formattedPhoneNumber);

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = "Lead",
                    CustomerTypeTblId = 1, // Assuming 1 is the ID for 'Lead' type
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CustomerContactInfos = new List<CustomerContactInfo>
                    {
                        new CustomerContactInfo
                        {
                            ContactInfoTbl = new ContactInfo
                            {
                                InfoType = "WhatsApp", // Set InfoType to WhatsApp
                                Info = formattedPhoneNumber,
                                DateCreated = DateTime.Now,
                                IsActive = true,
                                IsDeleted = false
                            },
                            DateCreated = DateTime.Now,
                            IsActive = true,
                            IsDeleted = false
                        }
                    }
                };

                await _customerRepository.AddAsync(customer);
                await _customerRepository.SaveChangesAsync();
            }

            return customer;
        }

        private async System.Threading.Tasks.Task AddCommunicationAndHandleConversationAsync(string phoneNumber, string message)
        {
            var customer = await CheckAndAddCustomerIfNotExistAsync(phoneNumber);

            // Check for open conversation status
            var openStatus = await _conversationStatusRepository.GetOpenStatusAsync();
            Conversation openConversation = null;

            if (openStatus != null)
            {
                //var allConversations = await _conversationRepository.GetAll();
                ////.Include(c => c.Communications)

                //openConversation = allConversations
                //    .Include(c => c.Communications)
                //    .FirstOrDefault(conv => conv.Communications.Any(com => com.CustomerTblId == customer.CustomerId) &&
                //                            conv.ConversationStatusTbls.Any(cs => cs.ConversationStatusId == openStatus.ConversationStatusId));

                openConversation = await _conversationStatusRepository.GetOpenConversationForCustomer(customer.CustomerId, openStatus.ConversationStatusId);


                _logger.LogInformation("Open conversation found: {ConversationId}", openConversation?.ConversationId);
            }


            // Add communication
            var communication = new Communication
            {
                CustomerTblId = customer.CustomerId,
                Content = message,
                DateCreated = DateTime.Now,
                ParentCommunicationTblId = openConversation?.ConversationId,
                ConversationTblId = openConversation?.ConversationId,
                IsActive = true,
                IsDeleted = false,
                ChannelTblId = 6 // Set ChannelTblId to 6
            };

            await _communicationRepository.AddAsync(communication);
            await _communicationRepository.SaveChangesAsync();

            // If no open conversation, create a new one
            if (openConversation == null)
            {
                var newConversation = new Conversation
                {
                    Guid = Guid.NewGuid(),
                    CallStartTime = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    DateCreated = DateTime.Now,
                    ConversationStatusTbls = new List<ConversationStatus> { openStatus }
                };

                await _conversationRepository.AddAsync(newConversation);
                await _conversationRepository.SaveChangesAsync();

                // Update communication with new conversation ID
                communication.ParentCommunicationTblId = newConversation.ConversationId;
                communication.ConversationTblId = newConversation.ConversationId;
                await _communicationRepository.SaveChangesAsync();
            }
        }

        private string FormatPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.StartsWith("972"))
            {
                phoneNumber = "0" + phoneNumber.Substring(3);
            }

            var atIndex = phoneNumber.IndexOf('@');
            if (atIndex != -1)
            {
                phoneNumber = phoneNumber.Substring(0, atIndex);
            }

            // Ensure the number starts with 0 for local numbers
            if (!phoneNumber.StartsWith("0"))
            {
                phoneNumber = "0" + phoneNumber;
            }

            return phoneNumber;
        }
    }
}
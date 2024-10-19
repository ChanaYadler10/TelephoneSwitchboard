using AutoMapper;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using Service.DTOs;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<CustomerDto> GetCustomerDetailsAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerWithDetailsAsync(customerId);
            if (customer == null)
            {
                _logger.LogWarning($"Customer with ID {customerId} not found.");
                return null;
            }

            var customerDto = _mapper.Map<CustomerDto>(customer);

            if (customerDto.Addresses.Any())
            {
                customerDto.PrimaryAddress = customerDto.Addresses.First().FullAddress;
            }

            var lastPurchase = await _customerRepository.GetCustomerLastPurchaseWithProductsAsync(customerId);
            if (lastPurchase != null)
            {
                customerDto.LastPurchase = new PurchaseDto
                {
                    PurchaseId = lastPurchase.PurchaseId,
                    PurchaseDate = lastPurchase.PurchaseDate,
                    Amount = lastPurchase.Amount,
                    Products = lastPurchase.Products.Select(p => new ProductDto
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                    }).ToList()
                };
            }

            return customerDto;
        }

        public async Task<List<ConversationDto>> GetCustomerConversationsAsync(int customerId)
        {
            var conversations = await _customerRepository.GetCustomerConversationsAsync(customerId);
            if (conversations == null || !conversations.Any())
            {
                _logger.LogInformation($"No conversations found for customer with ID {customerId}.");
                return new List<ConversationDto>();
            }

            return conversations.Select(c => new ConversationDto
            {
                ConversationId = c.ConversationId,
                Guid = c.Guid,
                CallStartTime = c.CallStartTime,
                CallDuration = c.CallDuration,
                CallEndTime = c.CallEndTime,
                IsActive = c.IsActive,
                IsDeleted = c.IsDeleted,
                DateCreated = c.DateCreated,
                DateModified = c.DateModified,
                Communications = c.Communications
                    .Where(com => com.CustomerTblId == customerId)
                    .Select(com => new CommunicationDto
                    {
                        CommunicationId = com.CommunicationId,
                        Subject = com.Subject,
                        Content = com.Content,
                        Customer = _mapper.Map<CustomerDto>(com.CustomerTbl),
                        ContactInfos = com.CustomerTbl.CustomerContactInfos
                            .Select(cci => _mapper.Map<ContactInfoDto>(cci.ContactInfoTbl))
                            .ToList()
                    })
                    .ToList()
            }).ToList();
        }

    }
}

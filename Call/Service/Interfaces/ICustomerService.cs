using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> GetCustomerDetailsAsync(int customerId);
        Task<List<ConversationDto>> GetCustomerConversationsAsync(int customerId);
    }
}

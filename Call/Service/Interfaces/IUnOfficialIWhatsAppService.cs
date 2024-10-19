using System.Threading.Tasks;
using Service.WhatsAppModels;
using Repository.Models;

namespace Service.Interfaces
{
    public interface IUnOfficialWhatsAppService
    {
        System.Threading.Tasks.Task SendMessageAsync(WhatsAppMessageRequest request);
        Task<Customer> CheckAndAddCustomerIfNotExistAsync(string phoneNumber);
        //IQueryable<T> GetAll();
    }
}

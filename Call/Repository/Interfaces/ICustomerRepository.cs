using Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerWithDetailsAsync(int customerId);
        Task<List<Conversation>> GetCustomerConversationsAsync(int customerId);
        Task<Purchase> GetCustomerLastPurchaseWithProductsAsync(int customerId);
        bool CustomerExists(int? customerId);
        Task<List<Customer>> GetAllCustomersAsync(); // New method
        System.Threading.Tasks.Task AddAsync(Customer customer); // New method
        System.Threading.Tasks.Task SaveChangesAsync(); // New method
        Task<Customer> GetCustomerWithPhoneAsync(string phoneNumber); // Add this method
    }
}

using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OmnicrmContext _omnicrmContext;

        public CustomerRepository(OmnicrmContext omnicrmContext)
        {
            _omnicrmContext = omnicrmContext;
        }

        public bool CustomerExists(int? customerId)
        {
            return _omnicrmContext.Customers.Any(c => c.CustomerId == customerId);
        }

        public async Task<Customer> GetCustomerWithDetailsAsync(int customerId)
        {
            return await _omnicrmContext.Customers
                .Include(c => c.CustomerTypeTbl)
                .Include(c => c.Addresses)
                .Include(c => c.CustomerContactInfos)
                    .ThenInclude(cci => cci.ContactInfoTbl)
                .Include(c => c.Purchases)
                .Include(c => c.Communications)
                    .ThenInclude(com => com.ConversationTbl)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId && c.IsActive == true && c.IsDeleted != true);
        }

        public async Task<List<Conversation>> GetCustomerConversationsAsync(int customerId)
        {
            return await _omnicrmContext.Conversations
                .Include(c => c.Communications)
                    .ThenInclude(com => com.CustomerTbl)
                .Include(c => c.Communications)
                    .ThenInclude(com => com.CustomerTbl.CustomerContactInfos)
                        .ThenInclude(cci => cci.ContactInfoTbl)
                .Where(c => c.Communications.Any(com => com.CustomerTblId == customerId))
                .ToListAsync();
        }

        public async Task<Purchase> GetCustomerLastPurchaseWithProductsAsync(int customerId)
        {
            return await _omnicrmContext.Purchases
                .Include(p => p.Products)
                .Where(p => p.CustomerTblId == customerId)
                .OrderByDescending(p => p.PurchaseDate)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _omnicrmContext.Customers
                .Include(c => c.CustomerContactInfos)
                    .ThenInclude(cci => cci.ContactInfoTbl)
                .Where(c => c.IsActive == true && c.IsDeleted != true)
                .ToListAsync();
        }

        public async System.Threading.Tasks.Task AddAsync(Customer customer)
        {
            await _omnicrmContext.Customers.AddAsync(customer);
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _omnicrmContext.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerWithPhoneAsync(string phoneNumber)
        {
            return await _omnicrmContext.Customers
                .Include(c => c.CustomerContactInfos)
                    .ThenInclude(cci => cci.ContactInfoTbl)
                .FirstOrDefaultAsync(c => c.CustomerContactInfos
                    .Any(ci => ci.ContactInfoTbl.InfoType == "WhatsApp" && ci.ContactInfoTbl.Info == phoneNumber));
        }
    }
}

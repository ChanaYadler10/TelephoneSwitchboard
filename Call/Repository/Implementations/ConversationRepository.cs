using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly OmnicrmContext _omnicrmContext;

        public ConversationRepository(OmnicrmContext omnicrmContext)
        {
            _omnicrmContext = omnicrmContext;
        }

        public async Task<List<Conversation>> GetAll()
        {
            return await _omnicrmContext.Conversations
                .Include(c => c.Communications)
                    .ThenInclude(com => com.CustomerTbl)
                        .ThenInclude(cust => cust.CustomerContactInfos)
                            .ThenInclude(cci => cci.ContactInfoTbl)
                .Where(c => c.IsActive == true && c.IsDeleted != true)
                .ToListAsync();
        }

        public async System.Threading.Tasks.Task AddAsync(Conversation conversation)
        {
            await _omnicrmContext.Conversations.AddAsync(conversation);
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _omnicrmContext.SaveChangesAsync();
        }






    }
}

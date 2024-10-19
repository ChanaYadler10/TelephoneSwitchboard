using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class ConversationStatusRepository : IConversationStatusRepository
    {
        private readonly OmnicrmContext _omnicrmContext;

        public ConversationStatusRepository(OmnicrmContext omnicrmContext)
        {
            _omnicrmContext = omnicrmContext;
        }

        public async Task<ConversationStatus> GetOpenStatusAsync()
        {
            var openConversation =  await _omnicrmContext.ConversationStatuses
                .FirstOrDefaultAsync(cs => cs.StatusName == "Open");
            return openConversation;
        }

        public async Task<Conversation> GetOpenConversationForCustomer(int customerId, int openStatusId)
        {
            return await _omnicrmContext.Conversations
                .Include(c => c.Communications)
                    .ThenInclude(com => com.CustomerTbl)
                        .ThenInclude(cust => cust.CustomerContactInfos)
                            .ThenInclude(cci => cci.ContactInfoTbl)
                .Include(c => c.ConversationStatusTbls)
                .Where(c => c.IsActive == true && c.IsDeleted != true)
                .FirstOrDefaultAsync(conv => conv.Communications.Any(com => com.CustomerTblId == customerId) &&
                                             conv.ConversationStatusTbls.Any(cs => cs.ConversationStatusId == openStatusId));
        }
    }
}

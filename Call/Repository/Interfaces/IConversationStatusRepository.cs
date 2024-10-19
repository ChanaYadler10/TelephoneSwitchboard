using Repository.Models;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IConversationStatusRepository
    {
        Task<ConversationStatus> GetOpenStatusAsync();

        Task<Conversation> GetOpenConversationForCustomer(int customerId, int openStatusId);
    }
}

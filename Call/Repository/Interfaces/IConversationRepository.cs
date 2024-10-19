using Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IConversationRepository
    {
        Task<List<Conversation>> GetAll();
        System.Threading.Tasks.Task AddAsync(Conversation conversation); // Add this method
        System.Threading.Tasks.Task SaveChangesAsync(); // Add this method
    }
}

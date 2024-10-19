using Repository.Models;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICommunicationRepository
    {
        System.Threading.Tasks.Task AddAsync(Communication communication); // Add this method
        System.Threading.Tasks.Task SaveChangesAsync(); // Add this method
    }
}

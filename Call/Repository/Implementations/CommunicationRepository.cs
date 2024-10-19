using Repository.Interfaces;
using Repository.Models;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class CommunicationRepository : ICommunicationRepository
    {
        private readonly OmnicrmContext _omnicrmContext;

        public CommunicationRepository(OmnicrmContext omnicrmContext)
        {
            _omnicrmContext = omnicrmContext;
        }

        public async System.Threading.Tasks.Task AddAsync(Communication communication)
        {
            await _omnicrmContext.Communications.AddAsync(communication);
        }

        public async System.Threading.Tasks.Task SaveChangesAsync()
        {
            await _omnicrmContext.SaveChangesAsync();
        }
    }
}

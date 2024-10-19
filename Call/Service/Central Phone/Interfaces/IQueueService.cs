using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Service.Central_Phone.Models;

namespace Service.Central_Phone.Interfaces
{
    public interface IQueueService : IBaseService
    {
        Task<ApiResponse<Queue>> GetQueuesAsync();
        Task<ApiResponse<Queue>> GetQueueDetailsAsync(int queueId);
    }
}

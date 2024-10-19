using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Service.Central_Phone.Models;
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Services;
using System.Text.Json;

namespace Service.Central_Phone.Services
{
    public class QueueService : BaseApiService, IQueueService
    {
        public QueueService(HttpClient client, IOptions<APISettings> apiSettings, ILogger<QueueService> logger)
            : base(client, apiSettings) { }

        public async Task<ApiResponse<Queue>> GetQueuesAsync()
        {
            var response = await GetAsync<Queue>(_apiSettings.Endpoints["QueueList"], new Dictionary<string, string>());
            
            return response;
        }

        public async Task<ApiResponse<Queue>> GetQueueDetailsAsync(int queueId)
        {
            if (queueId <= 0)
                throw new ArgumentException("Invalid Queue ID");

            var queryParams = new Dictionary<string, string>
            {
                { "id", queueId.ToString() }
            };

            var response = await GetAsync<Queue>(_apiSettings.Endpoints["QueueDetails"], queryParams);
            
            return response;
        }
    }
}

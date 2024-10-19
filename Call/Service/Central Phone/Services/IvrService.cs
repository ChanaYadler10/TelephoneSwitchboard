using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Models;
using System.Text.Json;
using System.Net.Http;


namespace Service.Central_Phone.Services
{
    public class IvrService : BaseApiService, IIvrService
    {
        public IvrService(HttpClient client, IOptions<APISettings> apiSettings, ILogger<IvrService> logger)
            : base(client, apiSettings) { }
       

        public async Task<ApiResponse<Ivr>> GetIvrListAsync()
        {
            var response = await GetAsync<Ivr>(_apiSettings.Endpoints["IvrList"], new Dictionary<string, string>());
                     
            return response;
        }


        public async Task<ApiResponse<Ivr>> GetIvrDestinationAsync(int ivr, string name)
        {
            if (ivr <= 0 || string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid IVR or name");

            var queryParams = new Dictionary<string, string>
            {
                { "ivr", ivr.ToString() },
                { "name", name }
            };
            var response = await GetAsync<Ivr>(_apiSettings.Endpoints["IvrDestination"], queryParams);
            
            return response;
        }
    }
}

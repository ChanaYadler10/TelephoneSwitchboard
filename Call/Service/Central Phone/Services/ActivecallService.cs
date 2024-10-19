using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Service.Central_Phone.Models;
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Services;
using Service.Central_Phone.Interfaces;

namespace Service.Central_Phone.Services
{
    public class ActivecallService : BaseApiService, IActivecall
    {
        public ActivecallService(HttpClient client, IOptions<APISettings> apiSettings)
            : base(client, apiSettings) { }

        public async Task<ApiResponse<Activecall>> GetActiveCallsAsync()
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", _apiSettings.AuthUsername },
                { "auth_password", _apiSettings.AuthPassword }
            };
            var response = await GetAsync<Activecall>(_apiSettings.Endpoints["GetActiveCalls"], queryParams);
            return response;
        }

        public async Task<ApiResponse<Activecall>> MakeCallAsync(string stype, string snumber, string ctype, string cnumber, int? wait = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", _apiSettings.AuthUsername },
                { "auth_password", _apiSettings.AuthPassword },
                { "stype", stype },
                { "snumber", snumber },
                { "ctype", ctype },
                { "cnumber", cnumber }
            };
            if (wait.HasValue)
            {
                queryParams.Add("wait", wait.Value.ToString());
            }
            var response = await GetAsync<Activecall>(_apiSettings.Endpoints["MakeCall"], queryParams);
            return response;
        }
    }
}

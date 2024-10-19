using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Models;

namespace Service.Central_Phone.Services
{
    public class CallHistoryService : BaseApiService, ICallHistoryService
    {
        public CallHistoryService(HttpClient client, IOptions<APISettings> apiSettings)
            : base(client, apiSettings) { }

        public async Task<ApiResponse<GetCallHistory>> GetFieldOfCompletedCallAsync(string uniqueid)
        {
            var queryParams = new Dictionary<string, string> { { "uniqueid", uniqueid } };
            var response = await GetAsync<GetCallHistory>(_apiSettings.Endpoints["GetCompletedCall"], queryParams);
            return response;
        }

        public async Task<ApiResponse<GetCallHistory>> GetArrayFieldsOfCompletedCallsAsync(DateTime start, DateTime end)
        {
            var startDate = DateTimeOffset.Now.AddDays(-7);
            var endDate = DateTimeOffset.Now;

            var startTimestamp = startDate.ToUnixTimeSeconds();
            var endTimestamp = endDate.ToUnixTimeSeconds();
            var queryParams = new Dictionary<string, string>
            {
                { "start", startTimestamp.ToString() },
                { "end", endTimestamp.ToString() }
            };
            var response = await GetAsync<GetCallHistory>(_apiSettings.Endpoints["ListCompletedCalls"], queryParams);
            return response;
        }
    }
}

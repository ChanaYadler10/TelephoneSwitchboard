using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Service.Central_Phone.Models;
using Service.Central_Phone.Interfaces;
using Service.Central_Phone.Services;


namespace Service.Central_Phone.Services
{
    public class TelephoneExtensionService : BaseApiService, ITelephoneExtensionService
    {
        public TelephoneExtensionService(HttpClient client, IOptions<APISettings> apiSettings)
            : base(client, apiSettings) { }

        public async Task<ApiResponse<TelephoneExtension>> GetTelephoneLines(string authUsername, string authPassword)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["GetTelephoneLines"], queryParams);
            return response;
        }

        public async Task<bool> DeleteTelephoneLine(string authUsername, string authPassword, string name)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword },
                { "name", name }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["DeleteTelephoneLine"], queryParams);
            return response.Responses != null && response.Responses.Any(r => r.Code == 204);
        }

        public async Task<ApiResponse<TelephoneExtension>> GetTelephoneLineFields(string authUsername, string authPassword, long name)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword },
                { "name", name.ToString() }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["GetTelephoneLineFields"], queryParams);
            return response;
        }

        public async Task<int?> CountTelephoneLinesWithSameHardwareAddress(string authUsername, string authPassword, string address)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword },
                { "address", address }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["CountTelephoneLines"], queryParams);
            return (int?)response.Data.First().count;
        }

        public async Task<ApiResponse<TelephoneExtension>>  GetLightweightTelephoneLinesList(string authUsername, string authPassword)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["ListPanelTelephoneLines"], queryParams);
            return response;
        }

        public async Task<bool> RebootHandset(string authUsername, string authPassword, string name)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword },
                { "name", name }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["RebootHandset"], queryParams);
            return response.Responses != null && response.Responses.Any(r => r.Code == 204);
        }

        public async Task<ApiResponse<TelephoneExtension>> GetSipRegistrations(string authUsername, string authPassword, string name)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword },
                { "name", name }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["ListSIPRegistrations"], queryParams);
            return response;
        }

        public async Task<ApiResponse<TelephoneExtension>> GetAllTelephoneLines(string authUsername, string authPassword)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["ListAllTelephoneLines"], queryParams);
            return response;
        }

        public async Task<bool> UnlockTelephoneLine(string authUsername, string authPassword, string name)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword },
                { "name", name }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["UnlockTelephoneLine"], queryParams);
            return response.Responses != null && response.Responses.Any(r => r.Code == 204);
        }

        public async Task<bool> UnregisterTelephoneLine(string authUsername, string authPassword, string name)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword },
                { "name", name }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["UnregisterTelephoneLine"], queryParams);
            return response.Responses != null && response.Responses.Any(r => r.Code == 204);
        }

        public async Task<ApiResponse<TelephoneExtension>> GetNextAvailableTelephoneLine(string authUsername, string authPassword)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["NextAvailableTelephoneLine"], queryParams);
            return response;
        }

        public async Task<bool> UpdateTelephoneLine(string authUsername, string authPassword, string name, string description)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "auth_username", authUsername },
                { "auth_password", authPassword },
                { "name", name },
                { "description", description }
            };
            var response = await GetAsync<TelephoneExtension>(_apiSettings.Endpoints["UpdateTelephoneLine"], queryParams);
            return response.Responses != null && response.Responses.Any(r => r.Code == 204);
        }
    }
}

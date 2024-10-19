using System;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service.Central_Phone.Models;
using Service.Central_Phone.Models.ModelsIcount;

namespace Service.Central_Phone.Services
{
    public class ICountClientService
    {
        private readonly HttpClient _httpClient;
        private readonly string cid = "kenionLTD";
        private readonly string user = "gvia";
        private readonly string pass = "gvia";
        public ICountClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<RootObject> GetClientsList(string phone = null, string email = null)
        {
            var fullRequest = new
            {
                cid,
                user,
                pass,
                phone = string.IsNullOrEmpty(phone) ? null : phone,
                email = string.IsNullOrEmpty(email) ? null : email
            };

            var json = JsonConvert.SerializeObject(fullRequest, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/client/get_list", content);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {errorMessage}");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RootObject>(responseContent);
            return result;
        }




        public async Task<ClientInfoResponse> GetClientInfo(int? client_id = null, string phone = null, string email = null)
        {
            if (client_id == null && string.IsNullOrEmpty(phone) && string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("At least one of the parameters: client_id, phone, or email must be provided.");
            }

            var fullRequest = new
            {
                cid,
                user,
                pass,
                client_id = client_id.HasValue ? client_id.Value : (int?)null,
                phone = string.IsNullOrEmpty(phone) ? null : phone,
                email = string.IsNullOrEmpty(email) ? null : email
            };

            var json = JsonConvert.SerializeObject(fullRequest, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/client/info", content);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {errorMessage}");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ClientInfoResponse>(responseContent);
            return result;
        }

        public async Task<CreateClientResponse> CreateClientAsync(CreateOrUpdateClientRequest request)
        {
            var requestBody = new Dictionary<string, object>
    {
        { "cid", "kenionLTD" },
        { "user", "gvia" },
        { "pass", "gvia" }
    };

            foreach (var prop in request.GetType().GetProperties())
            {
                var value = prop.GetValue(request);
                if (value != null && !(value is string stringValue && string.IsNullOrEmpty(stringValue)))
                {
                    requestBody.Add(ToSnakeCase(prop.Name), value);
                }
            }

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/client/create_or_update", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CreateClientResponse>(responseContent);
                return result;
            }

            return null;
        }


        private string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    if (i > 0) stringBuilder.Append('_');
                    stringBuilder.Append(char.ToLower(input[i]));
                }
                else
                {
                    stringBuilder.Append(input[i]);
                }
            }
            return stringBuilder.ToString();
        }




    }

}





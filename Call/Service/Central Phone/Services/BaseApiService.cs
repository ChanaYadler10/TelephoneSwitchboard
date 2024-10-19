using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Service.Central_Phone.Models;
using System.Text.Json;
using Newtonsoft.Json;


namespace Service.Central_Phone.Services
{
    public abstract class BaseApiService
    {
        protected readonly HttpClient _client;
        protected readonly APISettings _apiSettings;

        protected BaseApiService(HttpClient client, IOptions<APISettings> apiSettings)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _apiSettings = apiSettings.Value ?? throw new ArgumentNullException(nameof(apiSettings));

            if (string.IsNullOrEmpty(_apiSettings.BaseUrl) ||
                string.IsNullOrEmpty(_apiSettings.AuthUsername) ||
                string.IsNullOrEmpty(_apiSettings.AuthPassword) ||
                _apiSettings.Endpoints == null || _apiSettings.Endpoints.Count == 0)
            {
                throw new ArgumentException("Invalid API settings");
            }

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        //public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, string> queryParams) where T : class
        //{
        //    if (string.IsNullOrEmpty(endpoint)) throw new ArgumentException("Endpoint cannot be null or empty", nameof(endpoint));

        //    var uriBuilder = new UriBuilder($"{_apiSettings.BaseUrl}{endpoint}");
        //    var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
        //    query["auth_username"] = _apiSettings.AuthUsername;
        //    query["auth_password"] = _apiSettings.AuthPassword;

        //    foreach (var param in queryParams)
        //        query[param.Key] = param.Value;

        //    uriBuilder.Query = query.ToString();
        //    string requestUrl = uriBuilder.ToString();

        //    using (var client = new HttpClient())
        //    {
        //        var response = await client.GetAsync(requestUrl);

        //        // Handle redirect manually
        //        if (response.StatusCode == HttpStatusCode.MovedPermanently)
        //        {
        //            var newUrl = response.Headers.Location.ToString();
        //            response = await client.GetAsync(newUrl);
        //        }

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            var errorResponse = await response.Content.ReadAsStringAsync();
        //            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorResponse}");
        //        }

        //        var responseString = await response.Content.ReadAsStringAsync();
        //        var responseObject = JsonConvert.DeserializeObject<T>(responseString);
        //        return responseObject;
        //    }
        //}
        public async Task<ApiResponse<T>> GetAsync<T>(string endpoint, Dictionary<string, string> queryParams) where T : class
        {
            if (string.IsNullOrEmpty(endpoint)) throw new ArgumentException("Endpoint cannot be null or empty", nameof(endpoint));

            var uriBuilder = new UriBuilder($"{_apiSettings.BaseUrl}{endpoint}");
            var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
            query["auth_username"] = _apiSettings.AuthUsername;
            query["auth_password"] = _apiSettings.AuthPassword;

            foreach (var param in queryParams)
                query[param.Key] = param.Value;

            uriBuilder.Query = query.ToString();
            string requestUrl = uriBuilder.ToString();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(requestUrl);

                if (response.StatusCode == HttpStatusCode.MovedPermanently)
                {
                    var newUrl = response.Headers.Location.ToString();
                    response = await client.GetAsync(newUrl);
                }

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorResponse}");
                }

                var responseString = await response.Content.ReadAsStringAsync();
                var apiResponse = new ApiResponse<T>();
                var jsonObject = JsonConvert.DeserializeObject<JObject>(responseString);
                var dataToken = jsonObject["data"];

                if (dataToken != null)
                {
                    if (dataToken.Type == JTokenType.Array)
                    {
                        apiResponse.Data = dataToken.ToObject<List<T>>();
                    }
                    else if (dataToken.Type == JTokenType.Object)
                    {
                        var singleItem = dataToken.ToObject<T>();
                        apiResponse.Data = new List<T> { singleItem };
                    }
                }
                else
                {
                    // Handle case where "data" is missing or null
                    apiResponse.Data = new List<T>();
                }

                var responsesToken = jsonObject["responses"];
                if (responsesToken != null)
                {
                    apiResponse.Responses = responsesToken.ToObject<List<ResponseInfo>>();
                }

                return apiResponse;
            }
        }
        }





    }


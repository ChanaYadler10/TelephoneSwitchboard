using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Service.Central_Phone.Models;
using Service.Central_Phone.Models.ModelsIcount;

namespace Service.Central_Phone.Services
{
    public class IcountDocService
    {
        private readonly HttpClient _httpClient;
        private readonly string cid = "kenionLTD";
        private readonly string user = "gvia";
        private readonly string pass = "gvia";
        public IcountDocService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<RootDoc> SearchDocuments(int clientId, string startDate, string endDate)
        {
            var fullRequest = new
            {
                cid,
                user,
                pass,
                startDate = string.IsNullOrEmpty(startDate) ? null : startDate,
                endDate = string.IsNullOrEmpty(endDate) ? null : endDate,
                clientId = clientId > 0 ? (int?)clientId : null
            };

            var json = JsonConvert.SerializeObject(fullRequest, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/doc/search", content);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {errorMessage}");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RootDoc>(responseContent);
            return result;
        }





        public async Task<RootDoc> GetDocInfo(string doctype, int docnum)
        {
            var fullRequest = new
            {
                cid,
                user,
                pass,
                doctype,
                docnum
            };

            var json = JsonConvert.SerializeObject(fullRequest, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            Console.WriteLine("Request JSON: " + json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/doc/info", content);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {errorMessage}");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RootDoc>(responseContent);
            return result;
        }

        public async Task<RootDoc> CreateDocument(Service.Central_Phone.Models.ModelsIcount.DocumentRequest request)
        {
            var requestBody = new
            {
                cc = request.Cc,
                cid = cid,
                lang = request.Lang,
                pass = pass,
                user = user,
                email = request.Email,
                items = request.Items,
                vat_id = request.VatId,
                doctype = request.Doctype,
                email_cc = request.EmailCc,
                email_to = request.EmailTo,
                send_email = request.SendEmail,
                tax_exempt = request.TaxExempt,
                client_name = request.ClientName,
                email_cc_me = request.EmailCcMe,
                currency_code = request.CurrencyCode,
                email_to_client = request.EmailToClient
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/doc/create", data);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<RootDoc>(responseString);
                return result;
            }
            else
            {
                throw new Exception($"Error creating document: {responseString}");
            }
        }
    }
}
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
    public class ICountSuppliersService
    {
        private readonly HttpClient _httpClient;
        private readonly string cid = "kenionLTD";
        private readonly string user = "gvia";
        private readonly string pass = "gvia";
        public ICountSuppliersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        //public async Task<string> GetSuppliersList()//work
        //{
        //    var fullRequest = new
        //    {
        //        cid,
        //        user,
        //        pass
        //    };

        //    var json = JsonConvert.SerializeObject(fullRequest, new JsonSerializerSettings
        //    {
        //        NullValueHandling = NullValueHandling.Ignore
        //    });

        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/supplier/get_list", content);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        string errorMessage = await response.Content.ReadAsStringAsync();
        //        throw new Exception($"Request failed: {errorMessage}");
        //    }

        //    return await response.Content.ReadAsStringAsync();
        //}
        public async Task<SupplierResponse> GetSuppliersList()
        {
            var fullRequest = new
            {
                cid = "your_cid",  // החלף בערכים הנכונים
                user = "your_user",  // החלף בערכים הנכונים
                pass = "your_pass"   // החלף בערכים הנכונים
            };

            var json = JsonConvert.SerializeObject(fullRequest, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/supplier/get_list", content);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {errorMessage}");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            SupplierResponse supplierResponse = JsonConvert.DeserializeObject<SupplierResponse>(responseContent);

            return supplierResponse;
        }


        public async Task<string> GetSupplierInfo(int supplier_id)//work
        {
            if (supplier_id == null)
            {
                throw new ArgumentException("supplier_id canwt be null");
            }

            var fullRequest = new
            {
                cid,
                user,
                pass,
                supplier_id

            };

            var json = JsonConvert.SerializeObject(fullRequest, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/supplier/info", content);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {errorMessage}");
            }

            string responseContent = await response.Content.ReadAsStringAsync();
            //JObject jsonObject = JObject.Parse(responseContent);
            //string clientTypeId = jsonObject["client_type_id"].ToString();
            //dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
            return responseContent;
        }
        public async Task<string> AddSupplier(SupplierCreateRequest request)//work
        {
            var requestBody = new Dictionary<string, object>
        {
            { "cid", cid },
            { "user", user },
            { "pass", pass },
            { "supplier_name", request.SupplierName },
            { "vat_id", request.VatId },
            { "fname", request.Fname },
            { "lname", request.Lname },
            { "email", request.Email },
            { "phone", request.Phone },
            { "mobile", request.Mobile },
            { "fax", request.Fax },
            { "bus_country", request.BusCountry },
            { "bus_city", request.BusCity },
            { "bus_zip", request.BusZip },
            { "bus_street", request.BusStreet },
            { "bus_no", request.BusNo },
            { "bank", request.Bank },
            { "branch", request.Branch },
            { "account", request.Account },
            { "faccount", request.Faccount },
            { "wht_percent", request.WhtPercent },
            { "wht_validity", request.WhtValidity },
            { "notes", request.Notes }
        };

            var json = JsonConvert.SerializeObject(requestBody, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/supplier/add", content);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {errorMessage}");
            }

            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> UpdateSupplierAsync(SupplierUpdateRequest request)
        {
            var requestBody = new Dictionary<string, object>
        {
            { "cid", cid },
            { "user", user },
            { "pass", pass },
            { "supplier_id", request.SupplierId },
            { "supplier_name", request.SupplierName },
            { "vat_id", request.VatId },
            { "fname", request.Fname },
            { "lname", request.Lname },
            { "email", request.Email },
            { "phone", request.Phone },
            { "mobile", request.Mobile },
            { "fax", request.Fax },
            { "bus_country", request.BusCountry },
            { "bus_city", request.BusCity },
            { "bus_zip", request.BusZip },
            { "bus_street", request.BusStreet },
            { "bus_no", request.BusNo },
            { "bank", request.Bank },
            { "branch", request.Branch },
            { "account", request.Account },
            { "faccount", request.Faccount },
            { "wht_percent", request.WhtPercent },
            { "wht_validity", request.WhtValidity },
            { "notes", request.Notes }
        };

            var json = JsonConvert.SerializeObject(requestBody, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("https://api.icount.co.il/api/v3.php/supplier/update", content);

            if (!response.IsSuccessStatusCode)
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed: {errorMessage}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }


}




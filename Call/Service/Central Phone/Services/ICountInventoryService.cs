using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Service.Central_Phone.Models;

namespace Service.Central_Phone.Services

{
    public class IcountInventoryService
    {
        private static readonly HttpClient client = new HttpClient();


        private const string Cid = "kenionLTD";
        private const string User = "gvia";
        private const string Pass = "gvia";

        public async Task<string> GetInventoryItemInfo(int inventoryItemId)
        {
            var requestBody = new
            {
                cid = Cid,
                user = User,
                pass = Pass,
                inventory_item_id = inventoryItemId
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.icount.co.il/api/v3.php/inventory/get_item", data);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return responseString; // Return the successful response
            }
            else
            {
                throw new Exception($"Error retrieving item: {responseString}");
            }
        }
        public async Task<string> UpdateInventoryItem(UpdateInventoryItem item)
        {
            var requestBody = new
            {
                cid = Cid,
                user = User,
                pass = Pass,
                inventory_item_id = item.InventoryItemId,
                description = item.Description,
                long_description = item.LongDescription,
                sku = item.Sku,
                item_type_id = item.ItemTypeId,
                condition_id = item.ConditionId,
                unit_type_id = item.UnitTypeId,
                unitprice = item.UnitPrice,
                tax_exempt = item.TaxExempt,
                unit_price_includes_vat = item.UnitPriceIncludesVat,
                currency_id = item.CurrencyId,
                cost_amount = item.CostAmount,
                cost_currency_id = item.CostCurrencyId,
                stock = item.Stock,
                entry_date = item.EntryDate.ToString("yyyy-MM-dd"),
                warehouse_id = item.WarehouseId
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.icount.co.il/api/v3.php/inventory/update_item", data);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return responseString;
            }
            else
            {
                throw new Exception($"Error updating item: {responseString}");
            }
        }
        public async Task<string> DeleteInventoryItem(int inventoryItemId)
        {
            var requestBody = new
            {
                cid = Cid,
                user = User,
                pass = Pass,
                inventory_item_id = inventoryItemId
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.icount.co.il/api/v3.php/inventory/delete_item", data);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return responseString; 
            }
            else
            {
                throw new Exception($"Error deleting item: {responseString}");
            }
        }
        public async Task<string> AddItemToInventory(AddInventoryItem item)
    {
        var requestBody = new
        {
            cid = Cid,
            user = User,
            pass = Pass,
            description = item.Description,
            long_description = item.LongDescription,
            sku = item.Sku,
            item_type_id = item.ItemTypeId,
            condition_id = item.ConditionId,
            unit_type_id = item.UnitTypeId,
            unitprice = item.UnitPrice,
            tax_exempt = item.TaxExempt,
            unit_price_includes_vat = item.UnitPriceIncludesVat,
            currency_id = item.CurrencyId,
            cost_amount = item.CostAmount,
            cost_currency_id = item.CostCurrencyId,
            stock = item.Stock,
            entry_date = item.EntryDate.ToString("yyyy-MM-dd"),
            warehouse_id = item.WarehouseId
        };

        var json = JsonConvert.SerializeObject(requestBody);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://api.icount.co.il/api/v3.php/inventory/add_item", data);
        var responseString = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return responseString; // Return the successful response
        }
        else
        {
            throw new Exception($"Error adding item: {responseString}");
        }
    }
}
}

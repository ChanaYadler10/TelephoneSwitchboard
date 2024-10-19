namespace Service.Central_Phone.Models
{
    public class AddInventoryItem
    {
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Sku { get; set; }
        public int ItemTypeId { get; set; }
        public int ConditionId { get; set; }
        public int UnitTypeId { get; set; }
        public float UnitPrice { get; set; }
        public bool TaxExempt { get; set; }
        public bool UnitPriceIncludesVat { get; set; }
        public int CurrencyId { get; set; }
        public float CostAmount { get; set; }
        public int CostCurrencyId { get; set; }
        public float Stock { get; set; }
        public DateTime EntryDate { get; set; }
        public int WarehouseId { get; set; }
    }
    public class UpdateInventoryItem
    {
        public int InventoryItemId { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string Sku { get; set; }
        public int ItemTypeId { get; set; }
        public int ConditionId { get; set; }
        public int UnitTypeId { get; set; }
        public float UnitPrice { get; set; }
        public bool TaxExempt { get; set; }
        public bool UnitPriceIncludesVat { get; set; }
        public int CurrencyId { get; set; }
        public float CostAmount { get; set; }
        public int CostCurrencyId { get; set; }
        public float Stock { get; set; }
        public DateTime EntryDate { get; set; }
        public int WarehouseId { get; set; }
    }
}
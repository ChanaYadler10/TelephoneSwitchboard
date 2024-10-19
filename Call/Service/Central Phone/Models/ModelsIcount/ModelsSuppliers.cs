namespace Service.Central_Phone.Models
{
    public class SupplierCreateRequest
    {
        public string SupplierName { get; set; }
        public int VatId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string BusCountry { get; set; }
        public string BusCity { get; set; }
        public int BusZip { get; set; }
        public string BusStreet { get; set; }
        public string BusNo { get; set; }
        public int Bank { get; set; }
        public int Branch { get; set; }
        public int Account { get; set; }
        public int Faccount { get; set; }
        public float WhtPercent { get; set; }
        public string WhtValidity { get; set; }
        public string Notes { get; set; }
    }
    public class SupplierUpdateRequest
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int VatId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string BusCountry { get; set; }
        public string BusCity { get; set; }
        public int BusZip { get; set; }
        public string BusStreet { get; set; }
        public string BusNo { get; set; }
        public int Bank { get; set; }
        public int Branch { get; set; }
        public int Account { get; set; }
        public int Faccount { get; set; }
        public float WhtPercent { get; set; }
        public string WhtValidity { get; set; }
        public string Notes { get; set; }
    }
}
namespace Service.Central_Phone.Models
{
    public class CreateOrUpdateClientRequest
    {
        public string CustomClientId { get; set; }
        public int? VatId { get; set; }
        public string Email { get; set; }
        public string ClientName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string BusCountry { get; set; }
        public string BusState { get; set; }
        public string BusCity { get; set; }
        public int? BusZip { get; set; }
        public string BusStreet { get; set; }
        public string BusNo { get; set; }
        public string HomeCountry { get; set; }
        public string HomeState { get; set; }
        public string HomeCity { get; set; }
        public int? HomeZip { get; set; }
        public string HomeStreet { get; set; }
        public string HomeNo { get; set; }
        public int? Bank { get; set; }
        public int? Branch { get; set; }
        public int? Account { get; set; }
        public int? Faccount { get; set; }
        public string Notes { get; set; }
        public bool? Digsig { get; set; }
        public object CustomInfo { get; set; }
    }


}
namespace Service.Central_Phone.Models
{
    public class APISettings
    {
        public string BaseUrl { get; set; }
        public string AuthUsername { get; set; }
        public string AuthPassword { get; set; }
        public Dictionary<string, string> Endpoints { get; set; }
        public ICountSettings ICountSettings { get; set; }
        public string ApiUrl { get; set; } = "null";
        public string MediaUrl { get; set; } = "null";
        public string IdInstance { get; set; } = "null";
        public string ApiTokenInstance { get; set; } = "null";
        public string DefaultWhatsAppNumber { get; set; } = "null";

    }

    public class ICountSettings
    {
        public string Cid { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string CreateDocumentUrl { get; set; }
        public string GetDocInfoUrl { get; set; }
    }
    



}

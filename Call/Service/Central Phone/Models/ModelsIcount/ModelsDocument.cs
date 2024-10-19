namespace Service.Central_Phone.Models
{
    public class DocCreditCardInfo
    {
        public int Sum { get; set; }
        public int ExpYear { get; set; }
        public string CardType { get; set; }
        public int ExpMonth { get; set; }
        public string HolderId { get; set; }
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public string ConfirmationCode { get; set; }
    }

    public class DocItem
    {
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public string Description { get; set; }
    }

    public class DocumentRequest
    {
        public DocCreditCardInfo Cc { get; set; }
        public string Lang { get; set; } = "en";
        public string Email { get; set; }
        public List<DocItem> Items { get; set; }
        public string VatId { get; set; }
        public string Doctype { get; set; }
        public string EmailCc { get; set; }
        public string EmailTo { get; set; }
        public int SendEmail { get; set; }
        public int TaxExempt { get; set; }
        public string ClientName { get; set; }
        public int EmailCcMe { get; set; }
        public string CurrencyCode { get; set; }
        public int EmailToClient { get; set; }
    }

}
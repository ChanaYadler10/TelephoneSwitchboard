using Service.DTOs;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public string Name { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? Comments { get; set; }

    public CustomerTypeDto CustomerType { get; set; } // שינוי מ-string ל-CustomerTypeDto
    public List<AddressDto> Addresses { get; set; }
    public string PrimaryAddress { get; set; } // אופציונלי, אם רוצים לשמור כתובת ראשית

    public List<ContactInfoDto> ContactInfo { get; set; }
    public PurchaseDto LastPurchase { get; set; }

}

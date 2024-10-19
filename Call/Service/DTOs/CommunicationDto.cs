using Service.DTOs;

public class CommunicationDto
{
    public int CommunicationId { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public CustomerDto Customer { get; set; }
    public List<ContactInfoDto> ContactInfos { get; set; } // Add this property
}

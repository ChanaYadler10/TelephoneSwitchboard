namespace Repository.Models
{
    public class RepresentativeInfo
    {
        public string Id { get; set; } // Add this property
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> RoleClaims { get; set; }
    }
}

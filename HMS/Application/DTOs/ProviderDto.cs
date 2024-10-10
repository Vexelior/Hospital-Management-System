namespace Application.DTOs
{
    public class ProviderDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public Guid ProviderServiceLocationId { get; set; }
    }
}

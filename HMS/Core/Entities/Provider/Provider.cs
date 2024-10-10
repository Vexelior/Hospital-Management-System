using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Provider
{
    public class Provider
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public char TypeIndicator { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Address1 { get; set; }
        [MaxLength(100)]
        public string Address2 { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(5)]
        public string ZipCode { get; set; }
        [MaxLength(4)]
        public string ZipCode4 { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(60)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Fax { get; set; }
        public Guid ProviderServiceLocationId { get; set; }
    }
}

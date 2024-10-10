using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Provider
{
    public class ProviderServiceLocation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Address1 { get; set; }
        [MaxLength(50)]
        public string Address2 { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(5)]
        public string ZipCode { get; set; }
        [MaxLength(4)]
        public string ZipCode4 { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(60)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Website { get; set; }
        [MaxLength(450)]
        public string Description { get; set; }
        [MaxLength(10)]
        public string Fax { get; set; }
        [MaxLength(50)]
        public string ContactPerson { get; set; }
        [MaxLength(10)]
        public string ContactPersonPhone { get; set; }
        [MaxLength(100)]
        public string ContactPersonEmail { get; set; }
    }
}

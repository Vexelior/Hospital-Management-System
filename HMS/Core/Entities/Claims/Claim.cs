using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Claims
{
    public class Claim
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(13)]
        public string Number { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public ClaimStatus Status { get; set; }
        public ClaimType ClaimType { get; set; }
        public DateTime FirstDateOfService { get; set; }
        public DateTime LastDateOfService { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public DateTime DateOfResponse { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public Guid PatientId { get; set; }
        public Guid ProviderId { get; set; }
    }

    public enum ClaimStatus
    {
        Pending,
        Submitted,
        Rejected,
        Paid
    }

    public enum ClaimType
    {
        Medical,
        Dental,
        Vision,
        Pharmacy
    }
}

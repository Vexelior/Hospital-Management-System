using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Account
{
    public class AccountRequest
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();

        // Personal Information
        [Required]
        [StringLength(50)]
        public string FirstName { get; init; }

        [Required]
        [StringLength(60)]
        public string LastName { get; init; }

        [Required]
        public DateTime DateOfBirth { get; init; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; init; }

        [Phone]
        [StringLength(12)]
        public string PhoneNumber { get; init; }

        [Required]
        [StringLength(100)]
        public string Address1 { get; init; }

        [StringLength(100)]
        public string Address2 { get; init; }

        [Required]
        [StringLength(50)]
        public string City { get; init; }

        [Required]
        [StringLength(2)]
        public string State { get; init; }

        // Documents
        public byte[] MedicalLicense { get; init; }
        public byte[] Certification { get; init; }
        public byte[] Resume { get; init; }

        public AccountRequestStatus Status { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        [StringLength(450)]
        public string ReviewedBy { get; set; }
        [StringLength(500)]
        public string RejectionReason { get; set; }
    }

    public enum AccountRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}

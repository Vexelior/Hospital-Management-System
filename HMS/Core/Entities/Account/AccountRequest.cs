using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Account
{
    public class AccountRequest
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Personal Information
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        // Professional Information
        [Required]
        public string MedicalLicenseNumber { get; set; }

        [Required]
        public string Specialization { get; set; }

        public int YearsOfExperience { get; set; }

        // Documents
        public string MedicalLicenseDocumentPath { get; set; }
        public string CertificationDocumentPath { get; set; }
        public string CVDocumentPath { get; set; }

        // Status
        public AccountRequestStatus Status { get; set; }

        public DateTime SubmittedAt { get; set; }

        public DateTime? ReviewedAt { get; set; }

        public string ReviewedBy { get; set; } // Admin User ID

        public string RejectionReason { get; set; }
    }

    public enum AccountRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
}

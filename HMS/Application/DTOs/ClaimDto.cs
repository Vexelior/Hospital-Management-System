namespace Application.DTOs
{
    public class ClaimDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public char Status { get; set; }
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
}

namespace Application.DTOs
{
    public class ClaimDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Number { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime FirstDateOfService { get; set; }
        public DateTime LastDateOfService { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public DateTime DateOfResponse { get; set; }
        public string TotalAmount { get; set; }
        public string AmountPaid { get; set; }
        public string PatientId { get; set; }
        public string ProviderId { get; set; }
    }
}

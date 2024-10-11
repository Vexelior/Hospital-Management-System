namespace Application.DTOs
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public bool IsOnline { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}

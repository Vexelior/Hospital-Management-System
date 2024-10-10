using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(60)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsOnline { get; set; }
    }
}

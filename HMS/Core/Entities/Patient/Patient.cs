using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Patient
{
    public class Patient
    {
        [Key] 
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(60)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [MaxLength(3)]
        public string Suffix { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
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
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(60)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string MaritalStatus { get; set; }
        public char Gender { get; set; }
    }
}

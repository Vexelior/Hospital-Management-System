using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PatientDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
    }
}

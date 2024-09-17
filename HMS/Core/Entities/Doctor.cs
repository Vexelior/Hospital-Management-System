using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DoctorSpecialty> Specialties { get; set; } = new List<DoctorSpecialty>();
        public List<DoctorPractice> Practices { get; set; } = new List<DoctorPractice>();
    }
}

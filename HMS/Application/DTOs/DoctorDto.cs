using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; init; }
        public List<DoctorSpecialty> Specialties { get; set; }
        public List<DoctorPractice> Practices { get; set; }
    }
}

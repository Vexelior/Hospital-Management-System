using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }
        public string? Name { get; set; }
        public List<DoctorSpecialty> DoctorSpecialties { get; set; } = new List<DoctorSpecialty>();
    }
}

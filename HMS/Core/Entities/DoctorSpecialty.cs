using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DoctorSpecialty
    {
        [Key]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty? Specialty { get; set; }
    }
}

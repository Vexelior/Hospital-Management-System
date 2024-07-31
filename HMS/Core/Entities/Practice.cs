using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Practice
    {
        public int PracticeId { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public List<DoctorPractice> DoctorPractices { get; set; } = new List<DoctorPractice>();
    }
}

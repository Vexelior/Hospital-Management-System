using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}

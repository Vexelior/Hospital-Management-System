using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}

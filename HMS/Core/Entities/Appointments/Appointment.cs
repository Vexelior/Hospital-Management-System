using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Appointments
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public char Type { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime Requested { get; set; }
        public char Status { get; set; }
        [MaxLength(450)]
        public string Reason { get; set; }
    }
}

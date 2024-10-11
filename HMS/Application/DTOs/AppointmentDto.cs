using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public char Type { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime Requested { get; set; }
        public char Status { get; set; }
        public string Reason { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Appointments
{
    public class AppointmentStatus
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(450)]
        public string Description { get; set; }
        public char Code { get; set; }
    }
}

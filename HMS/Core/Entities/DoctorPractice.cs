using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DoctorPractice
    {
        [Key]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public int PracticeId { get; set; }
        public Practice? Practice { get; set; }
    }
}

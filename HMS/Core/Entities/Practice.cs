using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Practice
    {
        [Key]
        public int Id { get; init; }
        [Required]
        public string Name { get; init; }
        [Required]
        public string Location { get; init; }
        public List<DoctorPractice> DoctorPractices { get; init; } = [];
    }
}

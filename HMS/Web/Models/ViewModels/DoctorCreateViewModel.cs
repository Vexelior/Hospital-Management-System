using Core.Entities;

namespace Web.Models.ViewModels
{
    public class DoctorCreateViewModel
    {
        public string? Name { get; set; }
        public List<DoctorSpecialty> Specialties { get; set; } = new List<DoctorSpecialty>();
        public List<DoctorPractice> Practices { get; set; } = new List<DoctorPractice>();
    }
}

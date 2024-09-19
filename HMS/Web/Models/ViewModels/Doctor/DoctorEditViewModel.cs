using Core.Entities;

namespace Web.Models.ViewModels.Doctor
{
    public class DoctorEditViewModel
    {
        public string Name { get; init; }
        public IEnumerable<Specialty> Specialties { get; init; } = new List<Specialty>();
        public IEnumerable<Practice> Practices { get; init; } = new List<Practice>();
    }
}

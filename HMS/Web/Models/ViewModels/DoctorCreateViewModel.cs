using Core.Entities;

namespace Web.Models.ViewModels
{
    public class DoctorCreateViewModel
    {
        public string? Name { get; set; }
        public IEnumerable<Specialty> Specialties { get; set; } = new List<Specialty>();
        public IEnumerable<Practice> Practices { get; set; } = new List<Practice>();
    }
}

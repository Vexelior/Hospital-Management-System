using Core.Entities;

namespace Web.Models.ViewModels
{
    public class DoctorEditViewModel
    {
        public string? Name { get; set; }
        public List<Specialty>? Specialties { get; set; }
        public List<Practice>? Practices { get; set; }
    }
}

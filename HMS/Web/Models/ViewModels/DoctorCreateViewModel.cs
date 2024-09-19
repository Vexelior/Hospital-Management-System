using Application.DTOs;
using Core.Entities;

namespace Web.Models.ViewModels
{
    public class DoctorCreateViewModel
    {
        public string Name { get; init; }
        public IEnumerable<Specialty> Specialties { get; init; } = new List<Specialty>();
        public IEnumerable<PracticeDto> Practices { get; init; } = new List<PracticeDto>();
    }
}

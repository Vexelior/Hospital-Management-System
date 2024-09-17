using Application.DTOs;
using Core.Entities;

namespace Web.Models.ViewModels
{
    public class DoctorIndexViewModel
    {
        public IEnumerable<DoctorDto> Doctors { get; init; }
    }
}

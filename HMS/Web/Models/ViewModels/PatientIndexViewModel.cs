using Application.DTOs;
using Core.Entities;

namespace Web.Models.ViewModels
{
    public class PatientIndexViewModel
    {
        public IEnumerable<PatientDto> Patients { get; set; }
        public string AdditionalInfo { get; set; }
    }
}

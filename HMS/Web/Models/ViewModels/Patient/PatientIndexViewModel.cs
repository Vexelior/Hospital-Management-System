using Application.DTOs;
using Core.Entities;

namespace Web.Models.ViewModels.Patient
{
    public class PatientIndexViewModel
    {
        public IEnumerable<PatientDto> Patients { get; set; }
        public string AdditionalInfo { get; set; }
    }
}

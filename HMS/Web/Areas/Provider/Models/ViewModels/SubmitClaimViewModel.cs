using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace Web.Areas.Provider.Models.ViewModels
{
    public class SubmitClaimViewModel
    {
        public IEnumerable<SelectListItem> Patients { get; set; }
        public IEnumerable<SelectListItem> ClaimTypes { get; set; }
        [Required]
        public string TotalAmount { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string ProviderId { get; set; }
        [Required]
        public string SelectedPatientId { get; set; }
        [Required]
        public string SelectedClaimType { get; set; }
        public string TotalAmountComputed { get; set; }
    }
}

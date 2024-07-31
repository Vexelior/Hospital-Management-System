using Core.Entities;

namespace Web.Models.ViewModels
{
    public class DoctorIndexViewModel
    {
        public IEnumerable<Doctor>? Doctors { get; set; }
    }
}

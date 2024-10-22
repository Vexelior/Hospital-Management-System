using Application.DTOs;
using Web.Helpers;

namespace Web.Areas.Provider.Models.ViewModels
{
    public class ClaimIndexViewModel
    {
        public IEnumerable<ClaimDto> Claims { get; set; }
        public Pagination Pagination { get; set; }
        public string SearchString { get; set; }
        public string TotalAmountFormatted { get; set; }
        public string AmountPaidFormatted { get; set; }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Provider.Controllers
{
    [Area("Provider")]
    [Authorize(Roles = "Administrator,Provider")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

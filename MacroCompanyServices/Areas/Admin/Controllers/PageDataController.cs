using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

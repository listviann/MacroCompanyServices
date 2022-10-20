using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

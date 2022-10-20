using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

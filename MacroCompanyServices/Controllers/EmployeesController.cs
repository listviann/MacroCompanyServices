using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

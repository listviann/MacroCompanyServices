using MacroCompanyServices.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MacroCompanyServices.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            ViewBag.userName = userName;
            return View();
        }
    }
}

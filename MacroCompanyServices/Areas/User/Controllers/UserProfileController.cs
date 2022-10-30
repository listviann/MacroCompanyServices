using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MacroCompanyServices.Areas.User.Controllers
{
    [Area("User")]
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);

            ViewBag.userId = new Guid(userId);
            ViewBag.userName = userName;
            return View();
        }
    }
}

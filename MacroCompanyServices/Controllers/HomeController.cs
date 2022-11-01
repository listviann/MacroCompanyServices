using MacroCompanyServices.Domain;
using MacroCompanyServices.Models;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Diagnostics;

namespace MacroCompanyServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;

        public HomeController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            if (User.Identity!.IsAuthenticated && User.IsInRole("admin"))
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController(), new { area = "Admin" });
            }

            if (User.Identity!.IsAuthenticated && User.IsInRole("ordinary_user"))
            {
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController(), new { area = "User" });
            }

            return View(_dataManager.PagesData.GetPageDataByCodeWord("IndexPage"));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageDataController : Controller
    {
        private readonly DataManager _dataManager;

        public PageDataController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.PagesData.GetPagesData());
        }

        public IActionResult Edit(string codeWord)
        {
            var entity = _dataManager.PagesData.GetPageDataByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(PageData model)
        {
            if (ModelState.IsValid)
            {
                _dataManager.PagesData.SavePageData(model);
                return RedirectToAction(nameof(PageDataController.Index), nameof(PageDataController).CutController());
            }

            return View(model);
        }
    }
}

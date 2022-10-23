using MacroCompanyServices.Areas.Admin.Models;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Models;
using MacroCompanyServices.Service;
using Microsoft.AspNetCore.Mvc;

namespace MacroCompanyServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageDataItemsController : Controller
    {
        private readonly DataManager _dataManager;

        public PageDataItemsController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index(string codeWord, int page = 1, PagesDataSortState sortOrder = PagesDataSortState.CodeWordAsc)
        {
            int pageSize = 3;

            IQueryable<PageData> pagesData = _dataManager.PagesData.GetPagesData();

            if (!string.IsNullOrEmpty(codeWord))
            {
                pagesData = pagesData.Where(p => p.CodeWord == codeWord);
            }

            pagesData = sortOrder switch
            {
                PagesDataSortState.CodeWordDesc => pagesData.OrderByDescending(p => p.CodeWord),
                PagesDataSortState.TitleAsc => pagesData.OrderBy(p => p.Title),
                PagesDataSortState.TitleDesc => pagesData.OrderByDescending(p => p.Title),
                PagesDataSortState.TextAsc => pagesData.OrderBy(p => p.Text),
                PagesDataSortState.TextDesc => pagesData.OrderByDescending(p => p.Text),
                _ => pagesData.OrderBy(p => p.CodeWord),
            };

            var count = pagesData.Count();
            var items = pagesData.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PagesDataIndexViewModel viewModel = new PagesDataIndexViewModel(items,
                new PageViewModel(count, page, pageSize),
                new PagesDataFilterViewModel(codeWord),
                new PagesDataSortViewModel(sortOrder));

            return View(viewModel);
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
                return RedirectToAction(nameof(PageDataItemsController.Index), nameof(PageDataItemsController).CutController());
            }

            return View(model);
        }
    }
}

using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Models;

namespace MacroCompanyServices.Areas.Admin.Models
{
    public class PagesDataIndexViewModel
    {
        public IEnumerable<PageData> PagesData { get; }
        public PageViewModel PageViewModel { get; }
        public PagesDataFilterViewModel FilterViewModel { get; }
        public PagesDataSortViewModel SortViewModel { get; }

        public PagesDataIndexViewModel(IEnumerable<PageData> pagesData, PageViewModel pageViewModel, 
            PagesDataFilterViewModel filterViewModel, PagesDataSortViewModel sortViewModel)
        {
            PagesData = pagesData;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}

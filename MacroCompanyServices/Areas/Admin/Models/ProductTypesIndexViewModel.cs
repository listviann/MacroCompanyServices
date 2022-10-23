using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Models;

namespace MacroCompanyServices.Areas.Admin.Models
{
    public class ProductTypesIndexViewModel
    {
        public IEnumerable<ProductType> ProductTypes { get; }
        public PageViewModel PageViewModel { get; }
        public ProductTypesFilterViewModel FilterViewModel { get; }
        public ProductTypesSortViewModel SortViewModel { get; }

        public ProductTypesIndexViewModel(IEnumerable<ProductType> productTypes, PageViewModel pageViewModel,
           ProductTypesFilterViewModel filterViewModel, ProductTypesSortViewModel sortViewModel)
        {
            ProductTypes = productTypes;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}

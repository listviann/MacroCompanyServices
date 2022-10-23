using MacroCompanyServices.Domain.Entities;

namespace MacroCompanyServices.Models
{
    public class ProductsIndexViewModel
    {
        public IEnumerable<Product> Products { get; }
        public PageViewModel PageViewModel { get; }
        public ProductsFilterViewModel FilterViewModel { get; }
        public ProductsSortViewModel SortViewModel { get; }

        public ProductsIndexViewModel(IEnumerable<Product> products, PageViewModel pageViewModel,
            ProductsFilterViewModel filterViewModel, ProductsSortViewModel sortViewModel)
        {
            Products = products;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}

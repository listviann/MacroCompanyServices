using MacroCompanyServices.Domain.Repositories.Abstract;

namespace MacroCompanyServices.Domain
{
    public class DataManager
    {
        public IEmployeeRepository Employees { get; set; }
        public IPageDataRepository PagesData { get; set; }
        public IProductRepository Products { get; set; }
        public IProductTypeRepository ProductTypes { get; set; }
        public ICartItemRepository CartItems { get; set; }

        public DataManager(IEmployeeRepository employees, IPageDataRepository pagesData,
            IProductRepository products, IProductTypeRepository productTypes, ICartItemRepository cartItems)
        {
            Employees = employees;
            PagesData = pagesData;
            Products = products;
            ProductTypes = productTypes;
            CartItems = cartItems;
        }
    }
}

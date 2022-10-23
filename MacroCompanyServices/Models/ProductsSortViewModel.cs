namespace MacroCompanyServices.Models
{
    public enum ProductsSortState
    {
        ProductNameAsc,
        ProductNameDesc,
        ProductPriceAsc,
        ProductPriceDesc,
        ProductTypeNameAsc,
        ProductTypeNameDesc,
        EmployeeNameAsc,
        EmployeeNameDesc,
        DateAddedAsc,
        DateAddedDesc
    }

    public class ProductsSortViewModel
    {
        public ProductsSortState ProductNameSort { get; }
        public ProductsSortState ProductTypeNameSort { get; }
        public ProductsSortState EmployeeNameSort { get; }
        public ProductsSortState ProductPriceSort { get; }
        public ProductsSortState DateAddedSort { get; }
        public ProductsSortState Current { get; }

        public ProductsSortViewModel(ProductsSortState sortOrder)
        {
            ProductNameSort = sortOrder == ProductsSortState.ProductNameAsc ? ProductsSortState.ProductNameDesc : ProductsSortState.ProductNameAsc;
            ProductTypeNameSort = sortOrder == ProductsSortState.ProductTypeNameAsc ? ProductsSortState.ProductTypeNameDesc : ProductsSortState.ProductTypeNameAsc;
            EmployeeNameSort = sortOrder == ProductsSortState.EmployeeNameAsc ? ProductsSortState.EmployeeNameDesc : ProductsSortState.EmployeeNameAsc;
            ProductPriceSort = sortOrder == ProductsSortState.ProductPriceAsc ? ProductsSortState.ProductPriceDesc : ProductsSortState.ProductPriceAsc;
            DateAddedSort = sortOrder == ProductsSortState.DateAddedAsc ? ProductsSortState.DateAddedDesc : ProductsSortState.DateAddedAsc;
            Current = sortOrder;
        }
    }
}

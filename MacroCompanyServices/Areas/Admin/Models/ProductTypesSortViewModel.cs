namespace MacroCompanyServices.Areas.Admin.Models
{
    public enum ProductTypeSortState
    {
        ProductTypeNameAsc,
        ProductTypeNameDesc
    }

    public class ProductTypesSortViewModel
    {
        public ProductTypeSortState ProductTypeNameSort { get; }
        public ProductTypeSortState Current { get; }

        public ProductTypesSortViewModel(ProductTypeSortState sortOrder)
        {
            ProductTypeNameSort = sortOrder == ProductTypeSortState.ProductTypeNameAsc ? ProductTypeSortState.ProductTypeNameDesc : ProductTypeSortState.ProductTypeNameAsc;
            Current = sortOrder;
        }
    }
}

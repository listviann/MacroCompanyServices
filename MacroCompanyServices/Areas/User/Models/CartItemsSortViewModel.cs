namespace MacroCompanyServices.Areas.User.Models
{
    public enum CartItemsSortState
    {
        ProductNameAsc,
        ProductNameDesc,
    }
    public class CartItemsSortViewModel
    {
        public CartItemsSortState ProductNameSort { get; }
        public CartItemsSortState Current { get; }

        public CartItemsSortViewModel(CartItemsSortState sortOrder)
        {
            ProductNameSort = sortOrder == CartItemsSortState.ProductNameAsc ? CartItemsSortState.ProductNameDesc : CartItemsSortState.ProductNameAsc;
            Current = sortOrder;
        }
    }
}

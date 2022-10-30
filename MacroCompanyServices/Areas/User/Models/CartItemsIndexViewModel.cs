using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Models;

namespace MacroCompanyServices.Areas.User.Models
{
    public class CartItemsIndexViewModel
    {
        public IEnumerable<CartItem> CartItems { get; }
        public PageViewModel PageViewModel { get; }
        public CartItemsFilterViewModel FilterViewModel { get; }
        public CartItemsSortViewModel SortViewModel { get; }

        public CartItemsIndexViewModel(IEnumerable<CartItem> cartItems, PageViewModel pageViewModel,
            CartItemsFilterViewModel filterViewModel, CartItemsSortViewModel sortViewModel)
        {
            CartItems = cartItems;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}

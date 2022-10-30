using MacroCompanyServices.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MacroCompanyServices.Areas.User.Models
{
    public class CartItemsFilterViewModel
    {
        public string SelectedName { get; }

        public CartItemsFilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}

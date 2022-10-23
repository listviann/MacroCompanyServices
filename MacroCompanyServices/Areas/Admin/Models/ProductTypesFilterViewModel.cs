namespace MacroCompanyServices.Areas.Admin.Models
{
    public class ProductTypesFilterViewModel
    {
        public string SelectedName { get; }

        public ProductTypesFilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}

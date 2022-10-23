namespace MacroCompanyServices.Areas.Admin.Models
{
    public class PagesDataFilterViewModel
    {
        public string? SelectedName { get; }

        public PagesDataFilterViewModel(string selectedName)
        {
            SelectedName = selectedName;
        }
    }
}

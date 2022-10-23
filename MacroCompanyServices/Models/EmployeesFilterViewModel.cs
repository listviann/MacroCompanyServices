using MacroCompanyServices.Domain.Entities;

namespace MacroCompanyServices.Models
{
    public class EmployeesFilterViewModel
    {
        public string SelectedName { get; }
        public string SelectedEmail { get; }

        public EmployeesFilterViewModel(string selectedName, string selectedEmail)
        {
            SelectedName = selectedName;
            SelectedEmail = selectedEmail;
        }
    }
}

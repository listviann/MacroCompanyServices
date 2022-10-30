using System.ComponentModel.DataAnnotations;

namespace MacroCompanyServices.Areas.User.Models
{
    public class EditUserViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string? UserName { get; set; }
    }
}

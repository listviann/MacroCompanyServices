using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroCompanyServices.Areas.User.Models
{
    [NotMapped]
    public class EditUserViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string? UserName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroCompanyServices.Areas.User.Models
{
    [NotMapped]
    public class ChangePasswordViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [UIHint("Password")]
        [Display(Name = "Old password")]
        public string? OldPassword { get; set; }

        [Required]
        [UIHint("Password")]
        [Display(Name = "New password")]
        public string? NewPassword { get; set; }

        [Required]
        [UIHint("Password")]
        [Display(Name = "Repeat password")]
        [Compare("NewPassword", ErrorMessage = "Passwords don't match")]
        public string? RepeatNewPassword { get; set; }
    }
}

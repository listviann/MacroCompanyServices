using System.ComponentModel.DataAnnotations;

namespace MacroCompanyServices.Domain.Entities
{
    public class PageData : BaseEntity
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Page title")]
        public override string Title { get; set; } = "Info page";

        [Display(Name = "Page data")]
        public override string Text { get; set; } = "The administrator adds data";
    }
}

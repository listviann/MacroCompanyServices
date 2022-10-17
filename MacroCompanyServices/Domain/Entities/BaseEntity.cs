using System.ComponentModel.DataAnnotations;

namespace MacroCompanyServices.Domain.Entities
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        public virtual string Title { get; set; }

        [Display(Name = "Description")]
        public virtual string Text { get; set; }

        [Display(Name = "Title SEO Metatag")]
        public string? MetaTitle { get; set; }

        [Display(Name = "Description SEO Metatag")]
        public string? MetaDescription { get; set; }

        [Display(Name = "Keywords SEO Metatag")]
        public string? MetaKeywords { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

        protected BaseEntity() => DateAdded = DateTime.Now;
    }
}

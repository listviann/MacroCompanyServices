using System.ComponentModel.DataAnnotations;

namespace MacroCompanyServices.Domain.Entities
{
    public class ProductType
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product type field cannot be empty")]
        [StringLength(150)]
        public string? Name { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}

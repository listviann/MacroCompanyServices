using System.ComponentModel.DataAnnotations;

namespace MacroCompanyServices.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Product name field cannot be empty")]
        [StringLength(200)]
        public string ProductName { get; set; }
        
        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public decimal ProductPrice { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

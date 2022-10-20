using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacroCompanyServices.Domain.Entities
{
    public enum EmployeePosition
    {
        [Display(Name = "Low")]
        Low,

        [Display(Name = "Middle")]
        Middle,

        [Display(Name = "High")]
        High
    }

    public class Employee : BaseEntity
    {
        [Required(ErrorMessage = "Employee's name field cannot be empty")]
        [Display(Name = "Employee's name")]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Employee's email")]
        [RegularExpression(@"[^@\s]+@[^@\s]+\.[^@\s]+$", 
            ErrorMessage = "Incorrect email format\n An example of a valid email pattern: testname@testmail.com")]
        [StringLength(254)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Employee's phone number field cannot be empty")]
        [Display(Name = "Employee's phone number")]
        [RegularExpression(@"\d{3}-\d{3}-\d{4}", 
            ErrorMessage = "Incorrect phone number format\nAn example of a valid phone number pattern: 111-222-3333.: 111-222-3333")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Employee's salary")]
        public decimal Salary { get; set; }

        [Display(Name = "Employee's birth date")]
        [Required(ErrorMessage = "Employee's birth date field cannot be empty")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Employee's position")]
        [Column(TypeName = "nvarchar(6)")]
        public EmployeePosition Position { get; set; }

        public List<Product> Products { get; set; } = new();
    }
}

using MacroCompanyServices.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MacroCompanyServices.Models
{
    public class ProductsFilterViewModel
    {
        public string SelectedName { get; }
        public Guid SelectedProductType { get; }
        public SelectList ProductTypes { get; }
        public Guid SelectedEmployee { get; }
        public SelectList Employees { get; }

        public ProductsFilterViewModel(List<ProductType> productTypes, List<Employee> employees, Guid employee, 
            Guid productType, string name)
        {
            productTypes.Insert(default, new ProductType() { Name = "All" });
            employees.Insert(default, new Employee() { Name = "All" });

            ProductTypes = new SelectList(productTypes, "Id", "Name", productType);
            Employees = new SelectList(employees, "Id", "Name", employee);

            SelectedProductType = productType;
            SelectedEmployee = employee;
            SelectedName = name;
        }
    }
}

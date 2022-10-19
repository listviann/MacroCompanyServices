using Microsoft.EntityFrameworkCore;
using MacroCompanyServices.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MacroCompanyServices.Domain
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<PageData> PagesData { get; set; } = null!;
        public DbSet<ProductType> ProductTypes { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // create admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            // create admin role
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "4784f618-2d8d-4a42-a78f-aae1ecec4bf5",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "macroadmin4"),
                SecurityStamp = String.Empty
            });
            
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "0995b24b-a1d1-46d7-a9f8-63367b9b5e33",
                UserId = "4784f618-2d8d-4a42-a78f-aae1ecec4bf5"
            });

            builder.Entity<PageData>().HasData(new PageData
            {
                Id = new Guid("7d2feb40-ae8a-4563-8b00-f5e842233e1e"),
                CodeWord = "IndexPage",
                Title = "Main"
            });

            builder.Entity<PageData>().HasData(new PageData
            {
                Id = new Guid("a80557f4-5468-4f58-8d65-e469acaea843"),
                CodeWord = "EmployeesPage",
                Title = "Employees"
            });

            builder.Entity<PageData>().HasData(new PageData
            {
                Id = new Guid("784d92e9-4136-45ba-b145-9c8bdba2b806"),
                CodeWord = "ProductsPage",
                Title = "Products",
            });

            builder.Entity<PageData>().HasData(new PageData
            {
                Id = new Guid("47a4a586-ec16-49d7-95d0-16ba7b80d69a"),
                CodeWord = "EmployeeInfo",
                Title = "Employee info"
            });

            builder.Entity<PageData>().HasData(new PageData
            {
                Id = new Guid("95d5f883-a4e6-4e14-9bef-98c1242a3022"),
                CodeWord = "ProductInfo",
                Title = "Product info"
            });

            //builder.Entity<Employee>().HasData(new Employee
            //{

            //});

            //builder.Entity<Product>().HasData(new Product
            //{

            //});

            //builder.Entity<ProductType>().HasData(new ProductType
            //{

            //});

            builder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();
            builder.Entity<Employee>().HasIndex(e => e.Password).IsUnique();
            builder.Entity<Employee>().HasIndex(e => e.PhoneNumber).IsUnique();
            builder.Entity<ProductType>().HasIndex(p => p.Name).IsUnique();
        }
    }
}

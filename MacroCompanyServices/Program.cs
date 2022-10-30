using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MacroCompanyServices.Service;
using MacroCompanyServices.Domain;
using MacroCompanyServices.Domain.Entities;
using MacroCompanyServices.Domain.Repositories.Abstract;
using MacroCompanyServices.Domain.Repositories.EntityFramework;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

// Add configuration settings from appsettings.json
builder.Configuration.Bind("Project", new Config());

// Add services to the container.
builder.Services.AddTransient<IPageDataRepository, EFPageDataRepository>();
builder.Services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddTransient<IProductTypeRepository, EFProductTypeRepository>();
builder.Services.AddTransient<ICartItemRepository, EFCartItemRepository>();
builder.Services.AddTransient<DataManager>();

// Add the database context
builder.Services.AddDbContext<MacroCompanyContext>(options => options.UseSqlServer(Config.ConnectionString));

// Set up the identity system
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
}).AddEntityFrameworkStores<MacroCompanyContext>().AddDefaultTokenProviders();

// Set up cookie authentication
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "macroCompanyServicesAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

// Set the admin area authorization policy
builder.Services.AddAuthorization(x =>
{
    // User must be an admin to go to the admin area
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
    x.AddPolicy("UserArea", policy => { policy.RequireRole("ordinary_user"); });
});

builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
    x.Conventions.Add(new UserAreaAuthorization("User", "UserArea"));
}).AddSessionStateTempDataProvider();// To enable the session based TempData provider

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "user",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using ETrade.Business.Abstract;
using ETrade.Business.Concrete;
using ETrade.DataAccess.Abstract;
using ETrade.DataAccess.Concrete.EFCore;
using ETrade.WebUI.Identity;
using ETrade.WebUI.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});

builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
    .AddDefaultTokenProviders();

// Seed Identity parameters
var userManager = builder.Services.BuildServiceProvider().GetService <UserManager<ApplicationUser>>();
var roleManager = builder.Services.BuildServiceProvider().GetService<RoleManager<IdentityRole>>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // password
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 0;

    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;    
    options.SignIn.RequireConfirmedPhoneNumber = false;

});


builder.Services.ConfigureApplicationCookie(options => {
    options.AccessDeniedPath = "/account/accessdenied";
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
    options.Cookie = new CookieBuilder()
    {
        HttpOnly = true,
        Name = "ETÝCARET Security Cookie",
        SameSite = SameSiteMode.Strict
    };

});

builder.Services.AddScoped<IProductDal,EfCoreProductDal>();
builder.Services.AddScoped<IProductService,ProductManager>();
builder.Services.AddScoped<ICategoryDal,EfCoreCategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();

builder.Services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

var app = builder.Build();


SeedDatabase.Seed();
app.UseStaticFiles();
app.CustomStaticFiles();  // örneðin bootstrap node_modules aracýðýlýðýyla projeye dahil ediyoruz.
app.UseAuthentication();
app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


    endpoints.MapControllerRoute(
        name: "product",
        pattern: "products/{category?}",
        defaults: new { controller = "Shop", action= "List" }
    );

    endpoints.MapControllerRoute(
      name: "adminProducts",
      pattern: "admin/products",
      defaults: new { controller = "Admin", action = "ProductList" }
    );

    endpoints.MapControllerRoute(
     name: "adminProducts",
     pattern: "admin/products/{id?}",
     defaults: new { controller = "Admin", action = "EditProducts" }
   );


    endpoints.MapControllerRoute(
      name: "adminCategories",
      pattern: "admin/categories",
      defaults: new { controller = "Admin", action = "CategoryList" }
    );

    endpoints.MapControllerRoute(
     name: "adminCategories",
     pattern: "admin/categories/{id?}",
     defaults: new { controller = "Admin", action = "EditCategory" }
   );

});

SeedIdentity.Seed(userManager, roleManager, app.Configuration).Wait();

app.Run();

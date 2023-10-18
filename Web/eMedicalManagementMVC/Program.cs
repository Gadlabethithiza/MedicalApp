using System.Configuration;
using eMedicalManagementMinimalAPI.Core.Interfaces;
using eMedicalManagementMinimalAPI.Core.Interfaces.Learning;
using eMedicalManagementMinimalAPI.Core.Interfaces.Medicals;
using eMedicalManagementMinimalAPI.Infrastructure.Data;
using eMedicalManagementMinimalAPI.Infrastructure.Repositories;
using eMedicalManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<UniversityDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddDbContext<MedicalManagementDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("eMedicalManagementMinimalAPIDbConnection"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});

//services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(
//        Configuration.GetConnectionString("DefaultConnection"),
//        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

#region Repositories
builder.Services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
builder.Services.AddTransient<IProvinceRepositoryAsync, ProvinceRepositoryAsync>();
builder.Services.AddTransient<IInstitutionRepositoryAsync, InstitutionRepositoryAsync>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddTransient<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
builder.Services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IRazorRenderService, RazorRenderService>();
builder.Services.AddRazorPages();
#endregion

//builder.Services.AddMvc().AddRazorPagesOptions(options =>
//{
//    options.Conventions.Add(new CustomPageRouteModelConvention());
//});

//builder.Services.Configure<RazorPagesOptions>(opt =>
//{
//    opt.RootDirectory = "/Views";
//    opt.Conventions.AddPageRoute("/Product", "/Product");
//    opt.Conventions.AddPageRoute("/ProvinceIndex", "/Provinces");

//    //opt.Conventions.AddPageRoute("/Provinces/Index", "{culture}/Provinces");

//    // Override an imported Razor Class Library
//    // Razor Pages Route
//    //opt.Conventions.AddAreaPageRoute(
//    //    areaName: "Provinces",
//    //    pageName: "/Index",
//    //    route: "/Index");
//});

//.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvcCore().AddAuthorization();//.AddJsonFormatting


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
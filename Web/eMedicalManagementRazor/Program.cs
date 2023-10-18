using eMedicalManagementMinimalAPI.Core.Interfaces;
using eMedicalManagementMinimalAPI.Core.Interfaces.Medicals;
using eMedicalManagementMinimalAPI.Infrastructure.Data;
using eMedicalManagementMinimalAPI.Infrastructure.Repositories;
using eMedicalManagementRazor.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<UniversityDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddDbContext<MedicalManagementDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("eMedicalManagementMinimalAPIDbConnection"));
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
builder.Services.AddTransient<IProvinceRepositoryAsync, ProvinceRepositoryAsync>();
builder.Services.AddTransient<IInstitutionRepositoryAsync, InstitutionRepositoryAsync>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
// Add services to the container.

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IRazorRenderService, RazorRenderService>();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


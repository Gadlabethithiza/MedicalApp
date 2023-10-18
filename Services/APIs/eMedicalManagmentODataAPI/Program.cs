//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Run();

using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMinimalAPI.Core.Interfaces.Learning;
using eMedicalManagementMinimalAPI.Infrastructure.Data;
using eMedicalManagementMinimalAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EnumType<CustomerType>();
    builder.EntitySet<Customer>("Customers");
    builder.EntitySet<Shape>("Shapes");
    builder.EntitySet<Company>("Companies");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(20)
        .Count()
        .Expand()
    );

//var modelBuilder = new ODataConventionModelBuilder();
//modelBuilder.EnumType<CustomerType>();
//modelBuilder.EntitySet<Customer>("Customers");
//modelBuilder.EntitySet<Shape>("Shapes");
//modelBuilder.EntitySet<Company>("Companies");

////services.AddControllers().AddOData(options => options.EnableAttributeRouting = false);
//builder.Services.AddControllers()
//    .AddOData(options => options.EnableQueryFeatures(null)
//    .AddRouteComponents(routePrefix: "odata",model: modelBuilder.GetEdmModel())
//    .Select()
//    .Filter()
//    .OrderBy()
//    .Count()
//    .Expand()
//    );

builder.Services.AddDbContext<BasicCrudDbContext>(options => options.UseInMemoryDatabase("BasicCrudDb"));
builder.Services.AddScoped<ICompanyRepo, CompanyRepositoryAsync>();

var app = builder.Build();

//https://learn.microsoft.com/en-us/odata/webapi-8/fundamentals/routing-overview
//app.UseODataRouteDebug();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

// Seed database
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var db = serviceScope.ServiceProvider.GetRequiredService<BasicCrudDbContext>();

    BasicCrudDbHelper.SeedDb(db);
    BasicCrudDbHelper.AddCompaniesData(db);
}

app.Run();
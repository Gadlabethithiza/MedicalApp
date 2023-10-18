using eMedicalManagementMinimalAPI.Core.Interfaces;
using eMedicalManagementMinimalAPI.Infrastructure.Data;
using eMedicalManagementMinimalAPI.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

namespace eMedicalManagementBasicAPI
{
    public class AppBuilder
	{
        public static WebApplication GetApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();

            //builder.Services.AddDbContext<MedicalManagementDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("eMedicalManagementMinimalAPIDbConnection")));


            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            #region DI Repositories
            builder.Services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            //builder.Services.AddTransient <IInstitutionRepositoryAsync, InstitutionRepositoryAsync();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var contact = new OpenApiContact()
            {
                Name = "Thulani Mathenjwa",
                Email = "thulani.mathenjwa@gmail.com",
                Url = new Uri("http://www.gcssolutions.co.za")
            };

            var license = new OpenApiLicense()
            {
                Name = "My Licensing Conditions",
                Url = new Uri("http://www.gcssolutions.co.za/license")
            };

            var information = new OpenApiInfo()
            {
                Version = "v1",
                Title = "eMedical Room Menagement Minimal API",
                Description = "this is used to test my skills in Minimal Api",
                TermsOfService = new Uri("http://www.gcssolutions.co.za/terms"),
                Contact = contact,
                License = license
            };

            builder.Services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", information);
            });


            var app = builder.Build();

            return app;
        }
    }
}


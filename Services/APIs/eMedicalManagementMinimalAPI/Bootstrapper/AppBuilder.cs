using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using eMedicalManagementMinimalAPI.DataAccess;
using Serilog;
using eMedicalManagementMinimalAPI.Services;
using eMedicalManagementMinimalAPI.Repositories;

namespace eMedicalManagementMinimalAPI.Bootstrapper
{
	public static class AppBuilder
	{
        public static WebApplication GetApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();

            // Use Serilog
            builder.Host.UseSerilog((hostContext, services, configuration) => {
                configuration
                    .WriteTo.File($"serilog-file-{DateTime.Now.ToString("yyyyMMdd")}.txt")
                    .WriteTo.Console();
            });

            // Add services to the container.
            //builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();

            //// Use Serilog - from configuration
            //builder.Host.UseSerilog(
            //    (hostingContext, loggerConfiguration) =>
            //        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

            ////use in-memory database
            //builder.Services.AddDbContext<AspnetRunContext>(c => c.UseInMemoryDatabase("AspnetRunConnection"));

            // Register Db Dependency
            builder.Services.AddDbContext<UniversityDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<MedicalManagementDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("eMedicalManagementMinimalAPIDbConnection")));

            // DI - Register repository 
            builder.Services.AddTransient<IRolesRepository, RolesRepository>();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();



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


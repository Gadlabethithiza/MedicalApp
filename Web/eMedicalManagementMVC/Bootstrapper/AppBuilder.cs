using System;
namespace eMedicalManagementMVC.Bootstrapper
{
    public static class AppBuilder
    {
        public static WebApplication GetApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var app = builder.Build();

            return app;
        }
	}
}


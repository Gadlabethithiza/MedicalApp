using System;
namespace eMedicalManagementMinimalAPI.Bootstrapper
{
	public static class RequestPipelineBuilder
	{
        public static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eMedical Room Menagement Minimal API");
                c.DefaultModelExpandDepth(-1);
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
        }
    }
}


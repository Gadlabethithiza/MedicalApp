using System;
using eMedicalManagementMinimalAPI.DataAccess;
using eMedicalManagementMinimalAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace eMedicalManagementMinimalAPI.APIs.Medicals
{
	public class ProvincesApi
	{
        public static void RegisterApis(WebApplication app)
        {
            var provinces = app.MapGroup("/api/provinces").WithTags("Provinces");

            //GET ALL
            provinces.MapGet("/", async (MedicalManagementDbContext db) =>
               await db.ProvinceItems.ToListAsync());

            // GET by id
            provinces.MapGet("/{id}", async (int id, MedicalManagementDbContext db) => {
                var province = await db.ProvinceItems.FirstOrDefaultAsync(x => x.ProvinceId == id);
                return province == null ? Results.NotFound() : Results.Ok(province);
            });

            // POST
            provinces.MapPost("/", async (ProvinceItem province, MedicalManagementDbContext db) =>
            {
                var _province = await db.ProvinceItems.FirstOrDefaultAsync(ie => ie.ProvinceName == province.ProvinceName);

                if (_province != null)
                {
                    province = _province;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(province.created_by))
                        province.created_by = "Portal Administrator";

                    if (string.IsNullOrWhiteSpace(province.modified_by))
                        province.modified_by = "Portal Administrator";

                    province.created_date = DateTime.Now;
                    province.modified_date = DateTime.Now;
                    province.guid = Guid.NewGuid();

                    await db.ProvinceItems.AddAsync(province);
                    await db.SaveChangesAsync();
                }

                return Results.Ok(province);
            });

            //PUT
            provinces.MapPut("/", async (ProvinceItem _province, MedicalManagementDbContext db) => {
                try
                {
                    var province = await db.ProvinceItems.FindAsync(_province.ProvinceId);
                    if (province is null)
                        return Results.NotFound();

                    province.ProvinceName = _province.ProvinceName;
                    //province.IsComplete = _province.IsComplete;
                    province.modified_date = DateTime.Now;
                    province.modified_by = _province.modified_by;

                    await db.SaveChangesAsync();
                    return Results.Ok(province);
                }
                catch (Exception ex)
                {
                    return Results.NoContent();

                }

            });

            // DELETE
            provinces.MapDelete("/{id}", async (int id, MedicalManagementDbContext db) =>
            {
                var province = await db.ProvinceItems.FirstOrDefaultAsync(x => x.ProvinceId == id);
                if (province == null)
                {
                    return Results.NotFound();
                }

                db.ProvinceItems.Remove(province);
                await db.SaveChangesAsync();
                return Results.Ok();
            });

        }
	}
}


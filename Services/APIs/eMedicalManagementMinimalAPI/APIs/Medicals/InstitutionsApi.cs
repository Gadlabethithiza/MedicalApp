using System;
using eMedicalManagementMinimalAPI.DataAccess;
using System.Data;
using Microsoft.EntityFrameworkCore;
using eMedicalManagementMinimalAPI.DataAccess.Models;

namespace eMedicalManagementMinimalAPI.APIs.Medicals
{
	public class InstitutionsApi
	{
        public static void RegisterApis(WebApplication app)
        {
            var institutions = app.MapGroup("/api/institutions").WithTags("Institutions");

            institutions.MapGet("/", async (MedicalManagementDbContext db) =>
                await db.InstitutionItems.ToListAsync());

            // GET by id
            institutions.MapGet("/{id}", async (int id, MedicalManagementDbContext db) => {
                var institution = await db.InstitutionItems.FirstOrDefaultAsync(x => x.InstitutionId == id);
                return institution == null ? Results.NotFound() : Results.Ok(institution);
            });

            // GET by identity
            institutions.MapGet("/{identity_id}", async (string identity_id, MedicalManagementDbContext db) => {
                var institution = await db.InstitutionItems.FirstOrDefaultAsync(x => x.InstitutionName == identity_id);
                return institution == null ? Results.NotFound() : Results.Ok(institution);
            });

            // POST
            institutions.MapPost("/", async (InstitutionItem institution, MedicalManagementDbContext db) =>
            {
                var _institution = await db.InstitutionItems.FirstOrDefaultAsync(ie => ie.InstitutionName == institution.InstitutionName);

                if (_institution != null)
                {
                    Results.Ok(_institution);
                }
                else
                {
                    await db.InstitutionItems.AddAsync(institution);
                    await db.SaveChangesAsync();
                }
            });

            // DELETE
            institutions.MapDelete("/{id}", async (int id, MedicalManagementDbContext db) =>
            {
                var institution = await db.InstitutionItems.FirstOrDefaultAsync(x => x.InstitutionId == id);
                if (institution == null)
                {
                    return Results.NotFound();
                }

                db.InstitutionItems.Remove(institution);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
	}
}


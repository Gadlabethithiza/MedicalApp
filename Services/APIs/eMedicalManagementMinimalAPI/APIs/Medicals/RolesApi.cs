using System;
using eMedicalManagementMinimalAPI.DataAccess;
using eMedicalManagementMinimalAPI.DataAccess.Models;
using eMedicalManagementMinimalAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace eMedicalManagementMinimalAPI.APIs.Medicals
{
	public class RolesApi
	{
        public static void RegisterApis(WebApplication app)
        {
            var roles = app.MapGroup("/api/roles").WithTags("Roles");

            // GET api/roles
            roles.MapGet("/", async (IRolesRepository repository) =>
                await repository.GetAll());

            // GET by id
            roles.MapGet("/{id}", async (int id, IRolesRepository repository) => {
                var role = await repository.GetById(id);
                return role == null ? Results.NotFound() : Results.Ok(role);
            });

            // GET by identity
            roles.MapGet("/{identity_id}", async (string identity_id, IRolesRepository repository) => {
                var role = await repository.GetByRoleName(identity_id);
                return role == null ? Results.NotFound() : Results.Ok(role);
            });

            // POST
            roles.MapPost("/", async (RoleItem role, IRolesRepository repository) =>
            {
                var _role = await repository.GetByRoleName(role.RoleName);

                if (_role != null)
                {
                    Results.Ok(_role);
                }
                else
                {
                    await repository.Create(role);
                }
            });

            // DELETE
            roles.MapDelete("/{id}", async (int id, IRolesRepository repository) =>
            {
                var role = await repository.GetById(id);
                if (role == null)
                {
                    return Results.NotFound();
                }

                await repository.Delete(id);
                return Results.Ok();
            });

            /// <summary>
            /// Get List of all roles
            /// </summary>
            /// <returns>
            ///  The list of Roles.
            /// </returns>
            //// GET api/roles
            //roles.MapGet("/", async (MedicalManagementDbContext db) =>
            //    await db.RoleItems.ToListAsync());

            //// GET by id
            //roles.MapGet("/{id}", async (int id, MedicalManagementDbContext db) => {
            //    var role = await db.RoleItems.FirstOrDefaultAsync(x => x.RoleId == id);
            //    return role == null ? Results.NotFound() : Results.Ok(role);
            //});

            //// GET by identity
            //roles.MapGet("/{identity_id}", async (string identity_id, MedicalManagementDbContext db) => {
            //    var role = await db.RoleItems.FirstOrDefaultAsync(x => x.RoleName == identity_id);
            //    return role == null ? Results.NotFound() : Results.Ok(role);
            //});

            //// POST
            //roles.MapPost("/", async (RoleItem role, MedicalManagementDbContext db) =>
            //{
            //    var _role = await db.RoleItems.FirstOrDefaultAsync(ie => ie.RoleName == role.RoleName);

            //    if (_role != null)
            //    {
            //        Results.Ok(_role);
            //    }
            //    else
            //    {
            //        await db.RoleItems.AddAsync(role);
            //        await db.SaveChangesAsync();
            //    }
            //});

            //// DELETE
            //roles.MapDelete("/{id}", async (int id, MedicalManagementDbContext db) =>
            //{
            //    var role = await db.RoleItems.FirstOrDefaultAsync(x => x.RoleId == id);
            //    if (role == null)
            //    {
            //        return Results.NotFound();
            //    }

            //    db.RoleItems.Remove(role);
            //    await db.SaveChangesAsync();
            //    return Results.Ok();
            //});
        }
	}
}


using System;
using eMedicalManagementMinimalAPI.DataAccess;
using eMedicalManagementMinimalAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace eMedicalManagementMinimalAPI.APIs.Medicals
{
	public class UsersApi
	{
        public static void RegisterApis(WebApplication app)
        {
            var users = app.MapGroup("/api/users").WithTags("Users");

            users.MapGet("/", async (MedicalManagementDbContext db) =>
               await db.UserItems.ToListAsync());


            // GET by id
            users.MapGet("/{id}", async (int id, MedicalManagementDbContext db) => {
                var user = await db.UserItems.FirstOrDefaultAsync(x => x.UserId == id);
                return user == null ? Results.NotFound() : Results.Ok(user);
            });

            // GET by identity
            users.MapGet("/{identity_id}", async (string identity_id, MedicalManagementDbContext db) => {
                var user = await db.UserItems.FirstOrDefaultAsync(x => x.user_identity == identity_id);
                return user == null ? Results.NotFound() : Results.Ok(user);
            });

            // POST
            users.MapPost("/", async (UserItem user, MedicalManagementDbContext db) =>
            {
                var _user = await db.UserItems.FirstOrDefaultAsync(ie => ie.user_identity == user.user_identity);

                if (_user != null)
                {
                    Results.Ok(_user);
                }
                else
                {
                    await db.UserItems.AddAsync(user);
                    await db.SaveChangesAsync();
                }
            });

            // DELETE
            users.MapDelete("/{id}", async (int id, MedicalManagementDbContext db) =>
            {
                var user = await db.UserItems.FirstOrDefaultAsync(x => x.UserId == id);
                if (user == null)
                {
                    return Results.NotFound();
                }

                db.UserItems.Remove(user);
                await db.SaveChangesAsync();
                return Results.Ok();
            });

        }
	}
}


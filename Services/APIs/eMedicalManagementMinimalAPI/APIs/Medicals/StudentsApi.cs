using System;
using Microsoft.EntityFrameworkCore;
using eMedicalManagementMinimalAPI.DataAccess;
using eMedicalManagementMinimalAPI.DataAccess.Models;

namespace eMedicalManagementMinimalAPI.APIs
{
	public static class StudentsApi
	{
        public static void RegisterApis(WebApplication app)
        {
            var students = app.MapGroup("/api/students").WithTags("Students");

            // GET
            students.MapGet("/", async (UniversityDbContext db) =>
                await db.Students.ToListAsync());

            // GET by id
            students.MapGet("/{id}", async (int id, UniversityDbContext db) =>
            {
                var student = await db.Students.FirstOrDefaultAsync(x => x.StudentID == id);
                //return student == null ? Results.NotFound() : Results.Ok(student);
                return Results.Ok(student);
            });

            // POST
            students.MapPost("/", async (StudentEntity student, UniversityDbContext db) =>
            {
                await db.Students.AddAsync(student);
                await db.SaveChangesAsync();
            });

            // DELETE
            students.MapDelete("/{id}", async (int id, UniversityDbContext db) =>
            {
                var student = await db.Students.FirstOrDefaultAsync(x => x.StudentID == id);
                if (student == null)
                {
                    return Results.NotFound();
                }

                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
    }
}


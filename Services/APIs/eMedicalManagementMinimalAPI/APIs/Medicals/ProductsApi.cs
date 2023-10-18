using System;
using Microsoft.EntityFrameworkCore;
using eMedicalManagementMinimalAPI.DataAccess;
using eMedicalManagementMinimalAPI.DataAccess.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace eMedicalManagementMinimalAPI.APIs
{
	public static class ProductsApi
	{
        public static void RegisterApis(WebApplication app)
        {
            var products = app.MapGroup("/api/products").WithTags("Products");


            /// <summary>
            /// Get List of all products
            /// </summary>
            /// <returns>
            ///  The list of Products.
            /// </returns>
            // GET api/products
            products.MapGet("/", async (UniversityDbContext db) =>
                await db.Products.ToListAsync());

            // GET by id
            products.MapGet("/{id}", async (int id, UniversityDbContext db) => {
                var product = await db.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                return product == null ? Results.NotFound() : Results.Ok(product);
            });


            /// <summary>
            /// Creates new Product.
            /// </summary>
            /// <remarks>
            /// Sample request:
            /// 
            ///     POST api/products
            ///     {        
            ///       "firstName": "Mike",
            ///       "lastName": "Andrew",
            ///       "emailId": "Mike.Andrew@gmail.com"        
            ///     }
            /// </remarks>
            /// <param name="product"></param>
            /// <returns>A newly created employee</returns>
            /// <response code="201">Returns the newly created item</response>
            /// <response code="400">If the item is null</response> 
            // POST
            products.MapPost("/", async (ProductItem product, UniversityDbContext db) =>
            {
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
            });

            // DELETE
            products.MapDelete("/{id}", async (int id, UniversityDbContext db) =>
            {
                var product = await db.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                if (product == null)
                {
                    return Results.NotFound();
                }

                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
    }
}


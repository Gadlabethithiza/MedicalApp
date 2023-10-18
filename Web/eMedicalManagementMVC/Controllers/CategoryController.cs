using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMinimalAPI.Core.Interfaces.Learning;
using eMedicalManagementMinimalAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eMedicalManagementMVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepositoryAsync repository;
        private readonly ILogger _logger;

        public CategoryController(ILoggerFactory logger, ICategoryRepositoryAsync _repository)
        {
            repository = _repository;
            _logger = logger.CreateLogger<CategoryController>();
        }

        // GET: Product
        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var categoryList = await repository.GetListAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    categoryList = categoryList.OrderByDescending(s => s.Name).ToList();
                    break;
                default:
                    categoryList = categoryList.OrderBy(s => s.Id).ToList();
                    break;
            }

            return View(categoryList);
        }





        //Create Province
        public ViewResult AddCategory() => View();

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryItem item)
        {
            CategoryItem category = new CategoryItem();

            try
            {
                category = await repository.AddAsync(item);
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
        }





        //Get Province by ID
        //public ViewResult ViewCategory() => View();

        //[HttpPost]
        public async Task<IActionResult> ViewCategory(int id)
        {
            CategoryItem category = new CategoryItem();

            try
            {
                category = await repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

            }
            
            return View(category);
        }


        public async Task<IActionResult> UpdateCategory(int id)
        {
            CategoryItem category = new CategoryItem();

            try
            {
                category = await repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(int id, CategoryItem item)
        {
            try
            {
                var category = await repository.GetByIdAsync(id);

                if(category != null)
                {
                    await repository.UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            try
            {
                //if (id == null)
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                //if (saveChangesError.GetValueOrDefault())
                //{
                //    ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
                //}


                var category = await repository.GetByIdAsync(id);
                if (category != null)
                {
                    await repository.DeleteAsync(category);
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index");
        }


    }
}
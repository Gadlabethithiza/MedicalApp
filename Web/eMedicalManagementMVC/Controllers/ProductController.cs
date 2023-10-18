using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMinimalAPI.Core.Interfaces.Learning;
using eMedicalManagementMinimalAPI.Infrastructure.Repositories;
using eMedicalManagementMVC.Implementation;
using eMedicalManagementMVC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eMedicalManagementMVC.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepositoryAsync repository;
        private readonly ILogger _logger;

        public ProductController(ILoggerFactory logger, IProductRepositoryAsync _repository)
        {
            repository = _repository;
            _logger = logger.CreateLogger<ProductController>();
        }

        //GET: List of All Products
        [HttpGet]
        public async Task<IActionResult> ProductIndex(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var provinceList = await repository.GetListAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    provinceList = provinceList.OrderByDescending(s => s.Name).ToList();
                    break;
                //case "Date":
                //    provinceList = provinceList.OrderBy(s => s.created_date).ToList();
                //    break;
                //case "date_desc":
                //    provinceList = provinceList.OrderByDescending(s => s.created_date).ToList();
                //    break;
                default:
                    provinceList = provinceList.OrderBy(s => s.ProductId).ToList();
                    break;
            }

            return View(provinceList);
        }


        //POST: Create Product
        public async Task<IActionResult> AddProduct()
        {
            try
            {
                BindingCategories();

                //var dataList = await repository.GetCategories();
                //List<SelectListItem> items = new List<SelectListItem>();

                //items.Add(new SelectListItem
                //{
                //    Text = "Select Category",
                //    Value = "0",
                //    Selected = true
                //});

                //if (dataList.Count() > 0)
                //{
                //    foreach (var data in dataList)
                //    {
                //        items.Add(new SelectListItem
                //        {
                //            Text = data.Name,
                //            Value = data.Id.ToString()
                //        });
                //    }
                //}

                //ViewBag.CategoryItems = items;
                ////ViewData["CategoryItems"] = items;
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductItem item)
        {
            ProductItem product = new ProductItem();

            try
            {
                item.guid = System.Guid.NewGuid();
                product = await repository.AddAsync(item);
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("ProductIndex");
        }

        private void BindingCategories()
        {
            try
            {
                var dataList = repository.GetCategories();
                List<SelectListItem> items = new List<SelectListItem>();

                items.Add(new SelectListItem
                {
                    Text = "Select Category",
                    Value = "",
                    Selected = true
                });

                if (dataList.Result.Count() > 0)
                {
                    foreach (var data in dataList.Result)
                    {
                        items.Add(new SelectListItem
                        {
                            Text = data.Name,
                            Value = data.Id.ToString()
                        });
                    }
                }

                ViewBag.CategoryItems = items;
                //ViewData["CategoryItems"] = items;
            }
            catch (Exception ex)
            {

            }


        }



        public async Task<IActionResult> ViewProduct(int id)
        {
            ProductItem product = new ProductItem();

            try
            {
                BindingCategories();
                product = await repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

            }

            return View(product);
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            ProductItem category = new ProductItem();

            try
            {
                BindingCategories();
                category = await repository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {

            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(int id, ProductItem item)
        {
            try
            {
                var product = await repository.GetByIdAsync(id);

                if (product != null)
                {
                    item.ProductId = product.ProductId;
                    await repository.UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("ProductIndex");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await repository.GetByIdAsync(id);
                if (product != null)
                {
                    await repository.DeleteAsync(product);
                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("ProductIndex");
        }


    }
}


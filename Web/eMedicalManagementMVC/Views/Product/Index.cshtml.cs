using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMinimalAPI.Core.Interfaces.Learning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eMedicalManagementMVC.Views.Product
{
	public class IndexModel : PageModel
    {
        public List<ProductItem> products { get; set; }

        private readonly IProductRepositoryAsync _productRepository;
        public IndexModel(IProductRepositoryAsync productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IEnumerable<ProductItem> ProductList { get; set; } = new List<ProductItem>();
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _productRepository.GetListAsync();
            return Page();
        }

        //public void OnGet()
        //{


        //    //products = new List<ProductItem> {
        //    //    new ProductItem()
        //    //    {
        //    //        ProductId = 01,
        //    //        Name = "Name 1",
        //    //        Category = "thumb1.gif",
        //    //        Color = "Red",
        //    //        UnitPrice = 5.5,
        //    //        AvailableQuantity = 4
        //    //    },
        //    //    new ProductItem()
        //    //    {
        //    //        ProductId = 02,
        //    //        Name = "Name 2",
        //    //        Category = "thumb1.gif",
        //    //        Color = "Red",
        //    //        UnitPrice = 5.5,
        //    //        AvailableQuantity = 4
        //    //    },
        //    //    new ProductItem()
        //    //    {
        //    //        ProductId = 03,
        //    //        Name = "Name 3",
        //    //        Category = "thumb1.gif",
        //    //        Color = "Red",
        //    //        UnitPrice = 5.5,
        //    //        AvailableQuantity = 4
        //    //    }
        //    //};
        //}
    }
}

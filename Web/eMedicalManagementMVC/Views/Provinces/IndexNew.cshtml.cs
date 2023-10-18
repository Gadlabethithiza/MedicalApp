using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMVC.Interfaces;
using eMedicalManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eMedicalManagementMVC.Views.Provinces
{
	public class IndexModel : PageModel
    {
        private readonly IProvinceService _personService;

        public IndexModel(IProvinceService personService)
        {
            _personService = personService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        //public string NameSort { get; set; }
        //public string DateSort { get; set; }
        //public string CurrentFilter { get; set; }
        //public string CurrentSort { get; set; }

        //public List<ProvinceItem>? Data { get; set; }
        public ProvinceModel CustomerModel { get; set; }


        public async Task OnGetAsync()
        {
            this.CustomerModel = await this.GetCustomers(1);
        }

        public async Task OnPostSubmit(int currentPageIndex)
        {
            this.CustomerModel = await this.GetCustomers(currentPageIndex);
        }

        private async Task<ProvinceModel> GetCustomers(int currentPage)
        {
            int maxRows = 10;
            ProvinceModel customerModel = new ProvinceModel();

            //customerModel.ProvincesData = _personService.GetPaginatedResult(CurrentPage, PageSize).Result.OrderBy(customer => customer.ProvinceId)
            //            .Skip((currentPage - 1) * maxRows)
            //            .Take(maxRows).ToList();

            //customerModel.Count = await _personService.GetCount();

            //double pageCount = (double)((decimal)customerModel.Count / Convert.ToDecimal(maxRows));
            //customerModel.PageCount = (int)Math.Ceiling(pageCount);

            //customerModel.CurrentPageIndex = currentPage;

            return customerModel;
        }


        //public async Task OnGetAsync()
        //{
        //    //Data = await _personService.GetPaginatedResult(CurrentPage, PageSize);
        //    //Count = await _personService.GetCount();

        //    //https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/sort-filter-page?view=aspnetcore-7.0

        //    //NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    //DateSort = sortOrder == "Date" ? "date_desc" : "Date";

        //    //IQueryable<ProvinceItem> studentsIQ = from s in _context.Students
        //    //                                 select s;

        //    //switch (sortOrder)
        //    //{
        //    //    case "name_desc":
        //    //        studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
        //    //        break;
        //    //    case "Date":
        //    //        studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
        //    //        break;
        //    //    case "date_desc":
        //    //        studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
        //    //        break;
        //    //    default:
        //    //        studentsIQ = studentsIQ.OrderBy(s => s.LastName);
        //    //        break;
        //    //}

        //    //Students = await studentsIQ.AsNoTracking().ToListAsync();
        //}
    }
}

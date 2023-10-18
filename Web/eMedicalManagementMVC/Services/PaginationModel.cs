using System;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMVC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eMedicalManagementMVC.Services
{
    public class PaginationProvinceModel : PageModel
    {
        private readonly IProvinceService _personService;

        public PaginationProvinceModel(IProvinceService personService)
        {
            _personService = personService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<ProvinceItem>? Data { get; set; }

        public async Task OnGetAsync()
        {
            //Data = await _personService.GetPaginatedResult(CurrentPage, PageSize);
            //Count = await _personService.GetCount();
        }
    }
}


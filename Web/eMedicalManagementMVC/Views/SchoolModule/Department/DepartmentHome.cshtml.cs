using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eMedicalManagementMinimalAPI.Core.Entities;
using eMedicalManagementMinimalAPI.Core.Interfaces;
using eMedicalManagementMinimalAPI.Core.Interfaces.Medicals;
using eMedicalManagementMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace eMedicalManagementMVC.Views.SchoolModule.Department
{
	public class DepartmentHomeModel : PageModel
    {
        private readonly IProvinceRepositoryAsync _province;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRazorRenderService _renderService;
        private readonly ILogger<DepartmentHomeModel> _logger;

        public DepartmentHomeModel(ILogger<DepartmentHomeModel> logger, IProvinceRepositoryAsync province, IUnitOfWork unitOfWork, IRazorRenderService renderService)
        {
            _logger = logger;
            _province = province;
            _unitOfWork = unitOfWork;
            _renderService = renderService;
        }

        public IEnumerable<ProvinceItem> Provinces { get; set; }

        public void OnGet()
        {

        }

        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            Provinces = await _province.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = @"Province\_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<ProvinceItem>>(ViewData, Provinces)
            };
        }

        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync(@"Province\_CreateOrEdit", new ProvinceItem()) });
            else
            {
                var thisProvince = await _province.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync(@"Province\_CreateOrEdit", thisProvince) });
            }
        }

        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, ProvinceItem province)
        {
            if (ModelState.IsValid)
            {
                province.modified_date = DateTime.Now;

                if (id == 0)
                {
                    province.guid = System.Guid.NewGuid();
                    province.created_date = DateTime.Now;
                    province.created_by = "Portal Administrator Created";
                    province.modified_by = "Portal Administrator Created";
                    await _province.AddAsync(province);
                    await _unitOfWork.Commit();
                }
                else
                {
                    province.ProvinceId = id;
                    province.modified_by = "Portal Administrator Modified";
                    //province.guid = thisProvince.guid;
                    await _province.UpdateAsync(province);
                    await _unitOfWork.Commit();
                }

                Provinces = await _province.GetAllAsync();
                var html = await _renderService.ToStringAsync(@"Province\_ViewAll", Provinces);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync(@"Province\_CreateOrEdit", province);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var province = await _province.GetByIdAsync(id);
            await _province.DeleteAsync(province);
            await _unitOfWork.Commit();
            Provinces = await _province.GetAllAsync();
            var html = await _renderService.ToStringAsync(@"Province\_ViewAll", Provinces);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}

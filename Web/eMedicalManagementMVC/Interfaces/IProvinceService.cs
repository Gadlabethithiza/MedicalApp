using System;
using eMedicalManagementMinimalAPI.Core.Entities;

namespace eMedicalManagementMVC.Interfaces
{
	public interface IProvinceService
	{
        Task<List<ProvinceItem>> GetData();
        //Task<List<ProvinceItem>> GetPaginatedResult(int currentPage, int pageSize = 5);
        //Task<int> GetCount();
    }
}


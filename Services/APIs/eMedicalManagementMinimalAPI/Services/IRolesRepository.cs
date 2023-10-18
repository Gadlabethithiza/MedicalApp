using System;
using eMedicalManagementMinimalAPI.DataAccess.Models;

namespace eMedicalManagementMinimalAPI.Services
{
	public interface IRolesRepository
	{
        Task<RoleItem> Create(RoleItem role);
        Task<bool> Delete(int id);
        Task<List<RoleItem>> GetAll();
        Task<RoleItem?> GetById(int id);
        Task<RoleItem?> GetByRoleName(string role_name);
    }
}
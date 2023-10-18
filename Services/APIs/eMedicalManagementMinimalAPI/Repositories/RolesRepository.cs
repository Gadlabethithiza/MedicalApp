using System;
using eMedicalManagementMinimalAPI.DataAccess;
using eMedicalManagementMinimalAPI.DataAccess.Models;
using eMedicalManagementMinimalAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace eMedicalManagementMinimalAPI.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly MedicalManagementDbContext _db;

        public RolesRepository(MedicalManagementDbContext db)
        {
            _db = db;
        }

        public async Task<List<RoleItem>> GetAll()
        {
            return await _db.RoleItems.ToListAsync();
        }

        public async Task<RoleItem?> GetById(int id)
        {
            return await _db.RoleItems.FirstOrDefaultAsync(x => x.RoleId == id);
        }

        public async Task<RoleItem?> GetByRoleName(string role_name)
        {
            return await _db.RoleItems.FirstOrDefaultAsync(x => x.RoleName == role_name);
        }

        public async Task<RoleItem> Create(RoleItem role)
        {
            var _role = await _db.RoleItems.FirstOrDefaultAsync(ie => ie.RoleName == role.RoleName);

            if (_role != null)
            {
                return _role;
            }
            else
            {
                await _db.RoleItems.AddAsync(role);
                await _db.SaveChangesAsync();
                return role;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _db.RoleItems.FirstOrDefaultAsync(x => x.RoleId == id);
            if (student == null)
            {
                return false;
            }

            _db.RoleItems.Remove(student);
            await _db.SaveChangesAsync();
            return true;

        }
    }
}

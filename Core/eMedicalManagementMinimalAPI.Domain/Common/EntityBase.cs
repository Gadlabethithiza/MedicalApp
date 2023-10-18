using System;
namespace eMedicalManagementMinimalAPI.Domain.Common
{
    public abstract class EntityBase
    {
        public virtual int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
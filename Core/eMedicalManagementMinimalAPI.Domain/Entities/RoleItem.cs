using System;
using System.ComponentModel.DataAnnotations;
using eMedicalManagementMinimalAPI.Domain.Common;

namespace eMedicalManagementMinimalAPI.Domain.Entities
{
	public class RoleItem : AuditableEntityBase
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public Guid guid { get; set; }
    }
}


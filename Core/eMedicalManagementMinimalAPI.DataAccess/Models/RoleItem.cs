using System;
using System.ComponentModel.DataAnnotations;

namespace eMedicalManagementMinimalAPI.DataAccess.Models
{
	public class RoleItem
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


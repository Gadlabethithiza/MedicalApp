using System;
using System.ComponentModel.DataAnnotations;

namespace eMedicalManagementMinimalAPI.DataAccess.Models
{
	public class UserRoleItem
	{
        [Key]
        public int UserRoleId { get; set; }
        [Required]
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public Guid guid { get; set; }
    }
}


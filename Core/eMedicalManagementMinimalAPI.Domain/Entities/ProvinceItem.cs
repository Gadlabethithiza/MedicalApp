using System;
using System.ComponentModel.DataAnnotations;
using eMedicalManagementMinimalAPI.Domain.Common;

namespace eMedicalManagementMinimalAPI.Domain.Entities
{
	public class ProvinceItem : AuditableEntityBase
    {
        [Key]
        public int ProvinceId { get; set; }

        [StringLength(60, MinimumLength = 7)]
        [Required]
        public string ProvinceName { get; set; }       
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public Guid guid { get; set; }
    }
}


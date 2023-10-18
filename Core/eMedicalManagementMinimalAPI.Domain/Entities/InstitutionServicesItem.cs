using System;
using System.ComponentModel.DataAnnotations;
using eMedicalManagementMinimalAPI.Domain.Common;

namespace eMedicalManagementMinimalAPI.Domain.Entities
{
	public class InstitutionServicesItem : AuditableEntityBase
    {
        [Key]
        public int InstituitonServiceId { get; set; }
        [Required]
        public int InstituionId { get; set; }
        public int ServiceId { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public Guid guid { get; set; }
    }
}


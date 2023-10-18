using System;
using eMedicalManagementMinimalAPI.Domain.Common;

namespace eMedicalManagementMinimalAPI.Domain.Entities
{
	public class Grade : AuditableEntityBase
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
        public ICollection<StudentEntity> Students { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eMedicalManagementMinimalAPI.Domain.Common;

namespace eMedicalManagementMinimalAPI.Domain.Entities
{
    [Table("StudentEntity")]
    public class StudentEntity : AuditableEntityBase
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[]? Photo { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public Grade Grade { get; set; }
    }
}
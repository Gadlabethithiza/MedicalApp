using System;
namespace eMedicalManagementMinimalAPI.DataAccess.Models
{
	public class Grade
	{
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }
        public ICollection<StudentEntity> Students { get; set; }
    }
}
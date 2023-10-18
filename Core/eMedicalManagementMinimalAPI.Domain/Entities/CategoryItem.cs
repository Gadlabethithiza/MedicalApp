using System;
using System.ComponentModel.DataAnnotations;

namespace eMedicalManagementMinimalAPI.Domain.Entities
{
    public class CategoryItem
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid guid { get; set; }
    }
}
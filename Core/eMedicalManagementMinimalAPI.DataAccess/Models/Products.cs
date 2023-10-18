using System;
using System.ComponentModel.DataAnnotations;

namespace eMedicalManagementMinimalAPI.DataAccess.Models
{
    public class ProductItem
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public CategoryItem Category { get; set; }

        public string Color { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
        public Guid guid { get; set; }
    }

    public class CategoryItem
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid guid { get; set; }
    }
}
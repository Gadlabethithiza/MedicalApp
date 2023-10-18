using System;
using System.ComponentModel.DataAnnotations;
using eMedicalManagementMinimalAPI.Domain.Common;

namespace eMedicalManagementMinimalAPI.Domain.Entities
{
	//public class Products : AuditableEntityBase
	//{
 //       [Key]
 //       public int ProductId { get; set; }
 //       [Required]
 //       public string Name { get; set; }
 //       [Required]
 //       public string Category { get; set; }
 //       public string Color { get; set; }
 //       [Required]
 //       public double UnitPrice { get; set; }
 //       public int AvailableQuantity { get; set; }
 //   }


    public class ProductItem : AuditableEntityBase
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
}


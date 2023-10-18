using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMedicalManagementMinimalAPI.DataAccess.Models
{
	public class ProvinceItem
	{
        [Key]
        public int ProvinceId { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        //[Range(1, 100)]
        //[DataType(DataType.Currency)]

        [StringLength(60, MinimumLength = 7)]
        [Required]
        public string ProvinceName { get; set; }       
        public string created_by { get; set; }

        [DataType(DataType.Date)]
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }

        [DataType(DataType.Date)]
        public DateTime modified_date { get; set; }
        public Guid guid { get; set; }


        //[StringLength(60, MinimumLength = 3)]
        //[Required]
        //public string Title { get; set; } = string.Empty;

        //// [Display(Name = "Release Date")]
        //[DataType(DataType.Date)]
        //public DateTime ReleaseDate { get; set; }

        //[Range(1, 100)]
        //[DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal Price { get; set; }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        //[Required]
        //[StringLength(30)]
        //public string Genre { get; set; } = string.Empty;

        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        //[StringLength(5)]
        //[Required]
        //public string Rating { get; set; } = string.Empty;
    }
}


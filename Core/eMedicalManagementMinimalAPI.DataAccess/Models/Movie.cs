using System;
using System.ComponentModel.DataAnnotations;

namespace eMedicalManagementMinimalAPI.DataAccess.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

}


using System;
using System.ComponentModel.DataAnnotations;
using eMedicalManagementMinimalAPI.Domain.Common;

namespace eMedicalManagementMinimalAPI.Domain.Entities
{
    public class Movies : AuditableEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

}


using System;
using System.ComponentModel.DataAnnotations;

namespace eMedicalManagementMinimalAPI.DataAccess.Models
{
	public class UserItem
	{
        [Key]
        public int UserId { get; set; }
        [Required]
        public string user_identity { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public DateTime dob { get; set; }
        public int institutionId { get; set; }
        [Required]
        public string address { get; set; }
        public string city { get; set; }
        [Required]
        public string province { get; set; }
        [Required]
        public string gender { get; set; }
        public string telephone { get; set; }
        public string jobtitle { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string security_vrae { get; set; }
        public string security_antiwoord { get; set; }
        public string emergency_name { get; set; }
        public string emergency_tel { get; set; }
        //public int created_by_id { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public Guid guid { get; set; }
    }
}


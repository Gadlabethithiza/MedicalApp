using System;
using System.ComponentModel.DataAnnotations;

namespace eMedicalManagementMVC.Models
{
    public class InstitutionItemViewModel
    {
        [Key]
        public int InstitutionId { get; set; }
        public int ParentInstitutionId { get; set; }
        [Required]
        public string InstitutionName { get; set; }
        [Required]
        public string InstitutionDesc { get; set; }
        public DateTime cipc_registration_date { get; set; }
        public string cipc_company_no { get; set; }
        public string vat_no { get; set; }
        [Required]
        public string phy_addr_line1 { get; set; }
        [Required]
        public string phy_addr_line2 { get; set; }
        public string phy_addr_line3 { get; set; }
        public string phy_addr_line4 { get; set; }
        [Required]
        public string phy_addr_line5 { get; set; }
        public string postal_addr_line1 { get; set; }
        public string postal_addr_line2 { get; set; }
        public string postal_addr_line3 { get; set; }
        public string postal_addr_line4 { get; set; }
        public string postal_addr_line5 { get; set; }
        public int active { get; set; }
        public int created_by_id { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime modified_date { get; set; }
        public Guid guid { get; set; }
    }
}


using System;
namespace eMedicalManagementMinimalAPI.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public CustomerType CustomerType { get; set; }
        public decimal CreditLimit { get; set; }
        public DateTime CustomerSince { get; set; }
    }

    public enum CustomerType
    {
        Retail,
        Wholesale
    }
}
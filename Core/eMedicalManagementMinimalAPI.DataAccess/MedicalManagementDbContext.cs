using System;
using System.Diagnostics;
using eMedicalManagementMinimalAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace eMedicalManagementMinimalAPI.DataAccess
{
	public partial class MedicalManagementDbContext : DbContext
    {
        public MedicalManagementDbContext(DbContextOptions<MedicalManagementDbContext> options) : base(options)
        {

        }

        public virtual DbSet<UserItem> UserItems { get; set; }
        public virtual DbSet<InstitutionItem> InstitutionItems { get; set; }
        public virtual DbSet<ProvinceItem> ProvinceItems { get; set; }
        public virtual DbSet<RoleItem> RoleItems { get; set; }
        public virtual DbSet<UserRoleItem> UserRoleItems { get; set; }
        public virtual DbSet<InstitutionServicesItem> InstitutionServicesItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<UserItem>(entity =>
            {
                entity.ToTable("users", "support");

                entity.Property(e => e.UserId).HasColumnName("id");

                entity.Property(e => e.user_identity)
                    .HasColumnName("user_identity");

                entity.Property(e => e.first_name)
                    .HasMaxLength(100)
                    .HasColumnName("firstname");

                entity.Property(e => e.last_name)
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.dob)
                    .HasColumnType("datetime")
                    .HasColumnName("birth_date");

                entity.Property(e => e.institutionId).HasColumnName("institution_id");
                entity.Property(e => e.address).HasColumnName("address");
                entity.Property(e => e.city).HasColumnName("city");
                entity.Property(e => e.province).HasColumnName("province");
                entity.Property(e => e.telephone).HasColumnName("phonenumber");
                entity.Property(e => e.gender).HasColumnName("gender");
                entity.Property(e => e.jobtitle).HasColumnName("jobtitle");
                entity.Property(e => e.username).HasColumnName("username");
                entity.Property(e => e.password).HasColumnName("password");
                entity.Property(e => e.security_vrae).HasColumnName("security_question");
                entity.Property(e => e.security_antiwoord).HasColumnName("security_answer");
                entity.Property(e => e.emergency_name).HasColumnName("emergency_contact_name");
                entity.Property(e => e.emergency_tel).HasColumnName("emergency_contact_tel");
                entity.Property(e => e.created_by).HasColumnName("createdby");
                entity.Property(e => e.modified_by).HasColumnName("modifiedby");

                entity.Property(e => e.created_date)
                    .HasColumnType("datetime")
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.modified_date)
                    .HasColumnType("datetime")
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.guid).HasColumnName("Guid");

            });

            modelBuilder.Entity<InstitutionItem>(entity =>
            {
                entity.ToTable("institutions","support");              

                entity.Property(e => e.InstitutionId).HasColumnName("id");
                entity.Property(e => e.ParentInstitutionId).HasColumnName("parent_institution_id");

                entity.Property(e => e.InstitutionName)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.InstitutionDesc)
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.cipc_registration_date)
                  .HasColumnType("datetime")
                  .HasColumnName("cipc_registration_date");

                entity.Property(e => e.cipc_company_no)
                   .HasMaxLength(30)
                   .HasColumnName("cicp_company_no");

                entity.Property(e => e.vat_no)
                    .HasMaxLength(30)
                    .HasColumnName("vat_no");

                entity.Property(e => e.phy_addr_line1)
                    .HasMaxLength(100)
                    .HasColumnName("physical_address_line1");

                entity.Property(e => e.phy_addr_line2)
                   .HasMaxLength(40)
                   .HasColumnName("physical_address_line2");

                entity.Property(e => e.phy_addr_line3)
                   .HasMaxLength(30)
                   .HasColumnName("physical_address_line3");

                entity.Property(e => e.phy_addr_line4)
                   .HasMaxLength(20)
                   .HasColumnName("physical_address_line4");

                entity.Property(e => e.phy_addr_line5)
                   .HasMaxLength(5)
                   .HasColumnName("physical_address_line5");

                entity.Property(e => e.postal_addr_line1)
                    .HasMaxLength(30)
                    .HasColumnName("postal_address_line1");

                entity.Property(e => e.postal_addr_line2)
                   .HasMaxLength(40)
                   .HasColumnName("postal_address_line2");

                entity.Property(e => e.postal_addr_line3)
                   .HasMaxLength(30)
                   .HasColumnName("postal_address_line3");

                entity.Property(e => e.postal_addr_line4)
                   .HasMaxLength(20)
                   .HasColumnName("postal_address_line4");

                entity.Property(e => e.postal_addr_line5)
                   .HasMaxLength(5)
                   .HasColumnName("postal_address_line5");

                entity.Property(e => e.active).HasColumnName("active");
                entity.Property(e => e.created_by_id).HasColumnName("createdby_id");

                entity.Property(e => e.created_by).HasColumnName("createdby");
                entity.Property(e => e.modified_by).HasColumnName("modifiedby");

                entity.Property(e => e.created_date)
                    .HasColumnType("datetime")
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.modified_date)
                    .HasColumnType("datetime")
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.guid).HasColumnName("Guid");
            });

            modelBuilder.Entity<ProvinceItem>(entity =>
            {
                entity.ToTable("provinces","support");

                entity.Property(e => e.ProvinceId).HasColumnName("id");

                entity.Property(e => e.ProvinceName)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.created_by).HasColumnName("createdby");
                entity.Property(e => e.modified_by).HasColumnName("modifiedby");

                entity.Property(e => e.created_date)
                    .HasColumnType("datetime")
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.modified_date)
                    .HasColumnType("datetime")
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.guid).HasColumnName("Guid");
            });

            modelBuilder.Entity<RoleItem>(entity =>
            {
                entity.ToTable("roles", "support");

                entity.Property(e => e.RoleId).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.RoleDesc)
                   .HasMaxLength(50)
                   .HasColumnName("description");

                entity.Property(e => e.created_by).HasColumnName("createdby");
                entity.Property(e => e.modified_by).HasColumnName("modifiedby");

                entity.Property(e => e.created_date)
                    .HasColumnType("datetime")
                    .HasColumnName("createddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.modified_date)
                    .HasColumnType("datetime")
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.guid).HasColumnName("Guid");
            });




            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


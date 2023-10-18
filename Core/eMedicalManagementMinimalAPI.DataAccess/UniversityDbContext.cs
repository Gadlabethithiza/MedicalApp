using Microsoft.EntityFrameworkCore;
using eMedicalManagementMinimalAPI.DataAccess.Models;
using System.Data;

namespace eMedicalManagementMinimalAPI.DataAccess;
public partial class UniversityDbContext : DbContext
{
    public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
    {

    }

    public virtual DbSet<ProductItem> Products { get; set; }
    public virtual DbSet<Movies> Movies { get; set; }
    public virtual DbSet<StudentEntity> Students { get; set; }
    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<CategoryItem> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ProductItem>(entity =>
        {
            entity.ToTable("Products");
            entity.Property(o => o.UnitPrice).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<CategoryItem>(entity =>
        {
            entity.ToTable("Categories");
        });

        modelBuilder.Entity<Movies>(entity =>
        {
            entity.ToTable("Movie");
        });

        modelBuilder.Entity<StudentEntity>(entity =>
        {
            //entity.ToTable("StudentEntity");
            //entity.HasOne(d=>d.Grade)
            //      .WithMany(p=>p.Students)
            //      .HasForeignKey(d=>d.Grade)
            //      .Has
        });

        //modelBuilder.Entity<StudentEntity>(entity =>
        //{
        //    entity.ToTable("StudentEntity");
        //    entity.Property(o => o.StudentID).HasColumnName("StudentID").IsUnicode(true);
        //});

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
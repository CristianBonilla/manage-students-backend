using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageStudents.Contracts.SeedData;
using ManageStudents.Domain.Entities;

namespace ManageStudents.Infrastructure.Contexts.ManageStudents.Config;

class StudentConfig(ISeedData _seedData) : IEntityTypeConfiguration<StudentEntity>
{
  public void Configure(EntityTypeBuilder<StudentEntity> builder)
  {
    builder
      .ToTable("Student", "dbo")
      .HasKey(key => key.StudentId);
    builder
      .Property(property => property.StudentId)
      .HasDefaultValueSql("NEWID()");
    builder
      .Property(property => property.DocumentNumber)
      .HasColumnOrder(1)
      .HasMaxLength(20)
      .IsUnicode(false)
      .IsRequired();
    builder
      .Property(property => property.Mobile)
      .HasColumnOrder(2)
      .HasMaxLength(20)
      .IsUnicode(false)
      .IsRequired();
    builder
      .Property(property => property.Firstname)
      .HasColumnOrder(3)
      .HasMaxLength(50)
      .IsUnicode(false)
      .IsRequired();
    builder
      .Property(property => property.Lastname)
      .HasColumnOrder(4)
      .HasMaxLength(50)
      .IsUnicode(false)
      .IsRequired();
    builder
      .Property(property => property.Email)
      .HasColumnOrder(5)
      .HasMaxLength(100)
      .IsUnicode(false)
      .IsRequired();
    builder
      .Property(property => property.CreatedAt)
      .HasColumnOrder(6)
      .HasDefaultValueSql("GETUTCDATE()");
    builder
      .Property(property => property.UpdatedAt)
      .HasColumnOrder(7)
      .HasDefaultValueSql("GETUTCDATE()")
      .ValueGeneratedOnAddOrUpdate();
    builder
      .Property(property => property.Version)
      .HasColumnOrder(8)
      .IsRowVersion();
    builder
      .HasMany(many => many.Grades)
      .WithOne(one => one.Student)
      .HasForeignKey(key => key.StudentId)
      .OnDelete(DeleteBehavior.Cascade);
    builder
      .HasIndex(index => new
      {
        index.DocumentNumber,
        index.Mobile,
        index.Email
      })
      .IsUnique();
    if (_seedData is not null)
      builder.HasData(_seedData.Students.GetAll());
  }
}

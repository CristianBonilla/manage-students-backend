using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageStudents.Contracts.SeedData;
using ManageStudents.Domain.Entities;

namespace ManageStudents.Infrastructure.Contexts.ManageStudents.Config;

class TeacherConfig(ISeedData _seedData) : IEntityTypeConfiguration<TeacherEntity>
{
  public void Configure(EntityTypeBuilder<TeacherEntity> builder)
  {
    builder
      .ToTable("Teacher", "dbo")
      .HasKey(key => key.TeacherId);
    builder
      .Property(property => property.TeacherId)
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
      .Property(property => property.Subject)
      .HasColumnOrder(6)
      .HasConversion<string>()
      .IsRequired();
    builder
      .Property(property => property.CreatedAt)
      .HasColumnOrder(7)
      .HasDefaultValueSql("GETUTCDATE()");
    builder
      .Property(property => property.UpdatedAt)
      .HasColumnOrder(8)
      .HasDefaultValueSql("GETUTCDATE()")
      .ValueGeneratedOnAddOrUpdate();
    builder
      .Property(property => property.Version)
      .HasColumnOrder(9)
      .IsRowVersion();
    builder
      .HasMany(many => many.Grades)
      .WithOne(one => one.Teacher)
      .HasForeignKey(key => key.TeacherId)
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
      builder.HasData(_seedData.Teachers.GetAll());
  }
}

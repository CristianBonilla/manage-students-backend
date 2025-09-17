using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ManageStudents.Contracts.SeedData;
using ManageStudents.Domain.Entities;

namespace ManageStudents.Infrastructure.Contexts.ManageStudents.Config;

class GradeConfig(ISeedData _seedData) : IEntityTypeConfiguration<GradeEntity>
{
  public void Configure(EntityTypeBuilder<GradeEntity> builder)
  {
    builder
      .ToTable("Grade", "dbo")
      .HasKey(key => key.GradeId);
    builder
      .Property(property => property.GradeId)
      .HasDefaultValue("NEWID()");
    builder
      .Property(property => property.Value)
      .HasColumnOrder(1)
      .HasPrecision(2, 1)
      .IsRequired();
    builder
      .Property(property => property.CreatedAt)
      .HasColumnOrder(2)
      .HasDefaultValueSql("GETUTCDATE()");
    builder
      .Property(property => property.UpdatedAt)
      .HasColumnOrder(3)
      .HasDefaultValueSql("GETUTCDATE()")
      .ValueGeneratedOnAddOrUpdate();
    builder
      .Property(property => property.Version)
      .HasColumnOrder(4)
      .IsRowVersion();
    builder
      .HasOne(one => one.Teacher)
      .WithMany(many => many.Grades)
      .HasForeignKey(key => key.TeacherId);
    builder
      .HasOne(one => one.Student)
      .WithMany(many => many.Grades)
      .HasForeignKey(key => key.StudentId);
    builder
      .HasIndex(index => new
      {
        index.TeacherId,
        index.StudentId
      })
      .IsClustered();
    if (_seedData is not null)
      builder.HasData(_seedData.Grades.GetAll());
  }
}

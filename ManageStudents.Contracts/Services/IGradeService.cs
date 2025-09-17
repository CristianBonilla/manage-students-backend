using ManageStudents.Domain.Entities;

namespace ManageStudents.Contracts.Services;

public interface IGradeService
{
  Task<GradeEntity> AddGrade(GradeEntity grade, CancellationToken cancellationToken = default);
  Task<GradeEntity> UpdateGrade(GradeEntity grade, CancellationToken cancellationToken = default);
  Task<GradeEntity> DeleteGrade(GradeEntity grade, CancellationToken cancellationToken = default);
  IAsyncEnumerable<GradeEntity> GetGrades();
  Task<GradeEntity> FindGradeById(Guid gradeId);
}

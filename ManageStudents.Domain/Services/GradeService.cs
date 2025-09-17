using System.Net;
using ManageStudents.Contracts.Exceptions;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Entities;
using ManageStudents.Infrastructure.Repositories.Interfaces;

namespace ManageStudents.Domain.Services;

public class GradeService(
  IManageStudentsRepositoryContext _context,
  IGradeRepository _gradeRepository) : IGradeService
{
  public async Task<GradeEntity> AddGrade(GradeEntity grade, CancellationToken cancellationToken = default)
  {
    GradeEntity addedGrade = _gradeRepository.Create(grade);
    _ = await _context.SaveAsync(cancellationToken);

    return addedGrade;
  }

  public async Task<GradeEntity> UpdateGrade(GradeEntity grade, CancellationToken cancellationToken = default)
  {
    CheckGradeById(grade.GradeId);
    GradeEntity updatedGrade = _gradeRepository.Update(grade);
    _ = await _context.SaveAsync(cancellationToken);

    return updatedGrade;
  }

  public async Task<GradeEntity> DeleteGrade(GradeEntity grade, CancellationToken cancellationToken = default)
  {
    CheckGradeById(grade.GradeId);
    GradeEntity deletedGrade = _gradeRepository.Delete(grade);
    _ = await _context.SaveAsync(cancellationToken);

    return deletedGrade;
  }

  public IAsyncEnumerable<GradeEntity> GetGrades()
  {
    var grades = _gradeRepository
      .GetAll(order => order
        .OrderByDescending(grade => grade.Value))
      .ToAsyncEnumerable();

    return grades;
  }

  public Task<GradeEntity> FindGradeById(Guid gradeId) => Task.FromResult(GetGradeById(gradeId));

  private void CheckGradeById(Guid gradeId)
  {
    bool existingGrade = _gradeRepository.Exists(grade => grade.GradeId == gradeId);
    if (!existingGrade)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Grade not found with grade identifier \"{gradeId}\"");
  }

  private GradeEntity GetGradeById(Guid gradeId)
  {
    GradeEntity grade = _gradeRepository.Find([gradeId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Grade not found with grade identifier \"{gradeId}\"");

    return grade;
  }
}

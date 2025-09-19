using System.Net;
using ManageStudents.Contracts.Exceptions;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Entities;
using ManageStudents.Infrastructure.Repositories.Interfaces;

namespace ManageStudents.Domain.Services;

public class GradeService(
  IManageStudentsRepositoryContext _context,
  IGradeRepository _gradeRepository,
  ITeacherRepository _teacherRepository,
  IStudentRepository _studentRespository) : IGradeService
{
  public async Task<GradeEntity> AddGrade(GradeEntity grade, CancellationToken cancellationToken = default)
  {
    CheckTeacherById(grade.TeacherId);
    CheckStudentById(grade.StudentId);
    HasTeacherAndStudent(grade.TeacherId, grade.StudentId);
    GradeEntity addedGrade = _gradeRepository.Create(grade);
    _ = await _context.SaveAsync(cancellationToken);

    return addedGrade;
  }

  public async Task<GradeEntity> UpdateGrade(GradeEntity grade, CancellationToken cancellationToken = default)
  {
    CheckGradeById(grade.GradeId);
    CheckTeacherById(grade.TeacherId);
    CheckStudentById(grade.StudentId);
    HasTeacherAndStudentAssociatedGrades(grade.TeacherId, grade.StudentId);
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

  private void CheckTeacherById(Guid teacherId)
  {
    bool existingTeacher = _teacherRepository.Exists(teacher => teacher.TeacherId == teacherId);
    if (!existingTeacher)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Teacher not found with teacher identifier \"{teacherId}\"");
  }

  private void CheckStudentById(Guid studentId)
  {
    bool existingStudent = _studentRespository.Exists(student => student.StudentId == studentId);
    if (!existingStudent)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Student not found with student identifier \"{studentId}\"");
  }

  private GradeEntity GetGradeById(Guid gradeId)
  {
    GradeEntity grade = _gradeRepository.Find([gradeId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Grade not found with grade identifier \"{gradeId}\"");

    return grade;
  }

  private void HasTeacherAndStudent(Guid teacherId, Guid studentId)
  {
    bool existing = _gradeRepository.Exists(grade => grade.TeacherId == teacherId && grade.StudentId == studentId);
    if (existing)
      throw new ServiceErrorException(HttpStatusCode.BadRequest, $"There is already a grade associated with teacher and student");
  }

  private void HasTeacherAndStudentAssociatedGrades(Guid teacherId, Guid studentId)
  {
    bool existingTeacher = _gradeRepository.Exists(grade => grade.TeacherId == teacherId);
    if (!existingTeacher)
      throw new ServiceErrorException(HttpStatusCode.BadRequest, "The teacher has no associated grades");
    bool existingStudent = _gradeRepository.Exists(grade => grade.StudentId == studentId);
    if (!existingStudent)
      throw new ServiceErrorException(HttpStatusCode.BadRequest, "The student has no associated grades");
  }
}

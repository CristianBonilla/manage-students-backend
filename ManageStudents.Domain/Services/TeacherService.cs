using System.Net;
using ManageStudents.Contracts.Exceptions;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Entities;
using ManageStudents.Domain.Entities.Enums;
using ManageStudents.Helpers;
using ManageStudents.Infrastructure.Repositories.Interfaces;

namespace ManageStudents.Domain.Services;

public class TeacherService(
  IManageStudentsRepositoryContext _context,
  ITeacherRepository _teacherRepository,
  IGradeRepository _gradeRepository) : ITeacherService
{
  public async Task<TeacherEntity> AddTeacher(TeacherEntity teacher, CancellationToken cancellationToken = default)
  {
    await CheckTeacher(teacher, cancellationToken);
    TeacherEntity addedTeacher = _teacherRepository.Create(teacher);
    _ = await _context.SaveAsync(cancellationToken);

    return addedTeacher;
  }

  public async Task<TeacherEntity> UpdateTeacher(TeacherEntity teacher, CancellationToken cancellationToken = default)
  {
    CheckTeacherById(teacher.TeacherId);
    await CheckTeacher(teacher, cancellationToken);
    TeacherEntity updatedTeacher = _teacherRepository.Update(teacher);
    _ = await _context.SaveAsync(cancellationToken);

    return updatedTeacher;
  }

  public async Task<TeacherEntity> DeleteTeacher(TeacherEntity teacher, CancellationToken cancellationToken = default)
  {
    CheckTeacherById(teacher.TeacherId);
    TeacherEntity deletedTeacher = _teacherRepository.Delete(teacher);
    _ = await _context.SaveAsync(cancellationToken);

    return deletedTeacher;
  }

  public IAsyncEnumerable<TeacherEntity> GetTeachers()
  {
    var teachers = _teacherRepository
      .GetAll(order => order
        .OrderBy(teacher => teacher.DocumentNumber)
        .ThenBy(teacher => teacher.Firstname)
        .ThenBy(teacher => teacher.Lastname))
      .ToAsyncEnumerable();

    return teachers;
  }

  public IAsyncEnumerable<TeacherEntity> GetTeachersBySubject(SubjectName subject)
  {
    var teachers = _teacherRepository
      .GetByFilter(teacher => teacher.Subject == subject, order => order
        .OrderBy(teacher => teacher.DocumentNumber)
        .ThenBy(teacher => teacher.Firstname)
        .ThenBy(teacher => teacher.Lastname))
      .ToAsyncEnumerable();

    return teachers;
  }

  public Task<TeacherEntity> FindTeacherById(Guid teacherId) => Task.FromResult(GetTeacherById(teacherId));

  public Task<bool> HasAssociatedGrades(Guid teacherId)
  {
    CheckTeacherById(teacherId);

    return Task.FromResult(_gradeRepository.Exists(grade => grade.TeacherId == teacherId));
  }

  private void CheckTeacherById(Guid teacherId)
  {
    bool existingTeacher = _teacherRepository.Exists(teacher => teacher.TeacherId == teacherId);
    if (!existingTeacher)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Teacher not found with teacher identifier \"{teacherId}\"");
  }

  private async Task CheckTeacher(TeacherEntity teacherRequired, CancellationToken cancellationToken = default)
  {
    bool existingTeacher = await GetTeachers()
      .AnyAsync(teacher =>
        StringCommonHelper.IsStringEquivalent(teacher.DocumentNumber, teacherRequired.DocumentNumber) ||
        StringCommonHelper.IsStringEquivalent(teacher.Email, teacherRequired.Email) ||
        StringCommonHelper.IsStringEquivalent(teacher.Mobile, teacherRequired.Mobile),
        cancellationToken);
    if (existingTeacher)
      throw new ServiceErrorException(HttpStatusCode.BadRequest, "Teacher information provided may already exist: documentNumber, email or mobile");
  }

  private TeacherEntity GetTeacherById(Guid teacherId)
  {
    TeacherEntity teacher = _teacherRepository.Find([teacherId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Teacher not found with teacher identifier \"{teacherId}\"");

    return teacher;
  }
}

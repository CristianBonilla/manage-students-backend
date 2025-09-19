using System.Net;
using ManageStudents.Contracts.Exceptions;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Entities;
using ManageStudents.Helpers;
using ManageStudents.Infrastructure.Repositories.Interfaces;

namespace ManageStudents.Domain.Services;

public class StudentService(
  IManageStudentsRepositoryContext _context,
  IStudentRepository _studentRepository,
  IGradeRepository _gradeRepository,
  ITeacherRepository _teacherRepository) : IStudentService
{
  public async Task<StudentEntity> AddStudent(StudentEntity student, CancellationToken cancellationToken = default)
  {
    CheckStudent(student);
    StudentEntity addedStudent = _studentRepository.Create(student);
    _ = await _context.SaveAsync(cancellationToken);

    return addedStudent;
  }

  public async Task<StudentEntity> UpdateStudent(StudentEntity student, CancellationToken cancellationToken = default)
  {
    CheckStudentById(student.StudentId);
    CheckStudent(student, true);
    StudentEntity updatedStudent = _studentRepository.Update(student);
    _ = await _context.SaveAsync(cancellationToken);

    return updatedStudent;
  }

  public async Task<StudentEntity> DeleteStudent(StudentEntity student, CancellationToken cancellationToken = default)
  {
    CheckStudentById(student.StudentId);
    StudentEntity deletedStudent = _studentRepository.Delete(student);
    _ = await _context.SaveAsync(cancellationToken);

    return deletedStudent;
  }

  public IAsyncEnumerable<StudentEntity> GetStudents()
  {
    var students = _studentRepository
      .GetAll(order => order
        .OrderBy(student => student.DocumentNumber)
        .ThenBy(student => student.Firstname)
        .ThenBy(student => student.Lastname))
      .ToAsyncEnumerable();

    return students;
  }

  public IAsyncEnumerable<StudentEntity> GetStudentsExceptTeacherId(Guid teacherId)
  {
    CheckTeacherById(teacherId);
    var students = _studentRepository
      .GetAll()
      .Where(student =>
        !_gradeRepository.Exists(grade => grade.TeacherId == teacherId && grade.StudentId == student.StudentId) ||
        !_gradeRepository.Exists(grade => grade.StudentId == student.StudentId))
      .ToAsyncEnumerable();

    return students;
  }

  public Task<StudentEntity> FindStudentById(Guid studentId) => Task.FromResult(GetStudentById(studentId));

  public Task<bool> HasAssociatedGrades(Guid studentId)
  {
    CheckStudentById(studentId);

    return Task.FromResult(_gradeRepository.Exists(grade => grade.StudentId == studentId));
  }

  private void CheckStudentById(Guid studentId)
  {
    bool existingStudent = _studentRepository.Exists(student => student.StudentId == studentId);
    if (!existingStudent)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Student not found with student identifier \"{studentId}\"");
  }

  private void CheckStudent(StudentEntity studentRequired, bool isUpdate = false)
  {
    bool existingStudent = (!isUpdate ? _studentRepository.GetAll() : _studentRepository.GetByFilter(student => student.StudentId != studentRequired.StudentId))
      .Any(student =>
        StringCommonHelper.IsStringEquivalent(student.DocumentNumber, studentRequired.DocumentNumber) ||
        StringCommonHelper.IsStringEquivalent(student.Email, studentRequired.Email) ||
        StringCommonHelper.IsStringEquivalent(student.Mobile, studentRequired.Mobile));
    if (existingStudent)
      throw new ServiceErrorException(HttpStatusCode.BadRequest, "Student information provided may already exist: documentNumber, email or mobile");
  }

  private void CheckTeacherById(Guid teacherId)
  {
    bool existingTeacher = _teacherRepository.Exists(teacher => teacher.TeacherId == teacherId);
    if (!existingTeacher)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Teacher not found with teacher identifier \"{teacherId}\"");
  }

  private StudentEntity GetStudentById(Guid studentId)
  {
    StudentEntity student = _studentRepository.Find([studentId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Student not found with student identifier \"{studentId}\"");

    return student;
  }
}

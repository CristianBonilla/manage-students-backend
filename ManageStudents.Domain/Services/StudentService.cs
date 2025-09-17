using System.Net;
using ManageStudents.Contracts.Exceptions;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Entities;
using ManageStudents.Infrastructure.Repositories.Interfaces;

namespace ManageStudents.Domain.Services;

public class StudentService(
  IManageStudentsRepositoryContext _context,
  IStudentRepository _studentRepository,
  IGradeRepository _gradeRepository) : IStudentService
{
  public async Task<StudentEntity> AddStudent(StudentEntity student, CancellationToken cancellationToken = default)
  {
    StudentEntity addedStudent = _studentRepository.Create(student);
    _ = await _context.SaveAsync(cancellationToken);

    return addedStudent;
  }

  public async Task<StudentEntity> UpdateStudent(StudentEntity student, CancellationToken cancellationToken = default)
  {
    CheckStudentById(student.StudentId);
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
    var students = _gradeRepository
      .GetByFilter(grade => grade.TeacherId != teacherId)
      .DistinctBy(grade => new { grade.TeacherId, grade.StudentId })
      .Select(grade => _studentRepository.Find([grade.StudentId])!)
      .ToAsyncEnumerable();

    return students;
  }

  public Task<StudentEntity> FindStudentById(Guid studentId) => Task.FromResult(GetStudentById(studentId));

  public Task<bool> HasAssociatedGrades(Guid studentId) => Task.FromResult(_gradeRepository.Exists(grade => grade.StudentId == studentId));

  private void CheckStudentById(Guid studentId)
  {
    bool existingStudent = _studentRepository.Exists(student => student.StudentId == studentId);
    if (!existingStudent)
      throw new ServiceErrorException(HttpStatusCode.NotFound, $"Student not found with student identifier \"{studentId}\"");
  }

  private StudentEntity GetStudentById(Guid studentId)
  {
    StudentEntity student = _studentRepository.Find([studentId])
      ?? throw new ServiceErrorException(HttpStatusCode.NotFound, $"Student not found with student identifier \"{studentId}\"");

    return student;
  }
}

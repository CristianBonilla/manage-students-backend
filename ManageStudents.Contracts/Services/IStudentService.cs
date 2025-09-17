using ManageStudents.Domain.Entities;

namespace ManageStudents.Contracts.Services;

public interface IStudentService
{
  Task<StudentEntity> AddStudent(StudentEntity student, CancellationToken cancellationToken = default);
  Task<StudentEntity> UpdateStudent(StudentEntity student, CancellationToken cancellationToken = default);
  Task<StudentEntity> DeleteStudent(StudentEntity student, CancellationToken cancellationToken = default);
  IAsyncEnumerable<StudentEntity> GetStudents();
  IAsyncEnumerable<StudentEntity> GetStudentsExceptTeacherId(Guid teacherId);
  Task<StudentEntity> FindStudentById(Guid studentId);
  Task<bool> HasAssociatedGrades(Guid studentId);
}

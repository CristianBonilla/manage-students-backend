using ManageStudents.Domain.Entities;
using ManageStudents.Domain.Entities.Enums;

namespace ManageStudents.Contracts.Services;

public interface ITeacherService
{
  Task<TeacherEntity> AddTeacher(TeacherEntity teacher, CancellationToken cancellationToken = default);
  Task<TeacherEntity> UpdateTeacher(TeacherEntity teacher, CancellationToken cancellationToken = default);
  Task<TeacherEntity> DeleteTeacher(TeacherEntity teacher, CancellationToken cancellationToken = default);
  IAsyncEnumerable<TeacherEntity> GetTeachers();
  IAsyncEnumerable<TeacherEntity> GetTeachersBySubject(SubjectName subject);
  Task<TeacherEntity> FindTeacherById(Guid teacherId);
  Task<bool> HasAssociatedGrades(Guid teacherId);
}

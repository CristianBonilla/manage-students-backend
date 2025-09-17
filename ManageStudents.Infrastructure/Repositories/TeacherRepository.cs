using ManageStudents.Domain.Entities;
using ManageStudents.Infrastructure.Contexts.ManageStudents;
using ManageStudents.Infrastructure.Repositories.Base;
using ManageStudents.Infrastructure.Repositories.Interfaces;

namespace ManageStudents.Infrastructure.Repositories;

public class TeacherRepository(IManageStudentsRepositoryContext _context) : Repository<ManageStudentsContext, TeacherEntity>(_context), ITeacherRepository { }

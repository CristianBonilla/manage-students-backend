using ManageStudents.Contracts.Repository;
using ManageStudents.Domain.Entities;
using ManageStudents.Infrastructure.Contexts.ManageStudents;

namespace ManageStudents.Infrastructure.Repositories.Interfaces;

public interface IGradeRepository : IRepository<ManageStudentsContext, GradeEntity> { }

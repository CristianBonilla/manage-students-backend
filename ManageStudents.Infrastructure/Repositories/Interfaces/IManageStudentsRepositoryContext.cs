using ManageStudents.Contracts.Repository;
using ManageStudents.Infrastructure.Contexts.ManageStudents;

namespace ManageStudents.Infrastructure.Repositories.Interfaces;

public interface IManageStudentsRepositoryContext : IRepositoryContext<ManageStudentsContext> { }

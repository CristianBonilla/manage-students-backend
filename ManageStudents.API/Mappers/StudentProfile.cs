using AutoMapper;
using ManageStudents.Contracts.DTO.Student;
using ManageStudents.Domain.Entities;

namespace ManageStudents.API.Mappers;

class StudentProfile : Profile
{
  public StudentProfile()
  {
    CreateMap<StudentRequest, StudentEntity>()
      .ForMember(member => member.StudentId, options => options.Ignore())
      .ForMember(member => member.Grades, options => options.Ignore())
      .ForMember(member => member.CreatedAt, options => options.Ignore())
      .ForMember(member => member.UpdatedAt, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<StudentEntity, StudentResponse>()
      .ReverseMap()
      .ForMember(member => member.Grades, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
  }
}

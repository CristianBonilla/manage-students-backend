using AutoMapper;
using ManageStudents.Contracts.DTO.Teacher;
using ManageStudents.Domain.Entities;

namespace ManageStudents.API.Mappers;

class TeacherProfile : Profile
{
  public TeacherProfile()
  {
    CreateMap<TeacherRequest, TeacherEntity>()
      .ForMember(member => member.TeacherId, options => options.Ignore())
      .ForMember(member => member.Grades, options => options.Ignore())
      .ForMember(member => member.CreatedAt, options => options.Ignore())
      .ForMember(member => member.UpdatedAt, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<TeacherEntity, TeacherResponse>()
      .ReverseMap()
      .ForMember(member => member.Grades, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
  }
}

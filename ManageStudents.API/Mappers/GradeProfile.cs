using AutoMapper;
using ManageStudents.Contracts.DTO.Grade;
using ManageStudents.Domain.Entities;

namespace ManageStudents.API.Mappers;

class GradeProfile : Profile
{
  public GradeProfile()
  {
    CreateMap<GradeRequest, GradeEntity>()
      .ForMember(member => member.GradeId, options => options.Ignore())
      .ForMember(member => member.Teacher, options => options.Ignore())
      .ForMember(member => member.Student, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
    CreateMap<GradeEntity, GradeResponse>()
      .ReverseMap()
      .ForMember(member => member.Teacher, options => options.Ignore())
      .ForMember(member => member.Student, options => options.Ignore())
      .ForMember(member => member.Version, options => options.Ignore());
  }
}

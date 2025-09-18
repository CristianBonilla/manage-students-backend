using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using AutoMapper;
using ManageStudents.API.Filters;
using ManageStudents.Contracts.DTO.Teacher;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Entities;
using ManageStudents.Domain.Entities.Enums;

namespace ManageStudents.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[ServiceErrorExceptionFilter]
public class TeacherController(IMapper _mapper, ITeacherService _teacherService) : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TeacherResponse))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddTeacher([FromBody] TeacherRequest teacherRequest, CancellationToken cancellationToken)
  {
    TeacherEntity teacher = _mapper.Map<TeacherEntity>(teacherRequest);
    TeacherEntity addedTeacher = await _teacherService.AddTeacher(teacher, cancellationToken);
    TeacherResponse teacherResponse = _mapper.Map<TeacherResponse>(addedTeacher);

    return CreatedAtAction(nameof(AddTeacher), teacherResponse);
  }

  [HttpPut("{teacherId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> UpdateTeacher(Guid teacherId, [FromBody] TeacherRequest teacherRequest, CancellationToken cancellationToken)
  {
    TeacherEntity teacher = await _teacherService.FindTeacherById(teacherId);
    TeacherEntity updatedTeacher = _mapper.Map(teacherRequest, teacher);
    TeacherResponse teacherResponse = _mapper.Map<TeacherResponse>(await _teacherService.UpdateTeacher(updatedTeacher, cancellationToken));

    return Ok(teacherResponse);
  }

  [HttpDelete("{teacherId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> DeleteTeacher(Guid teacherId, CancellationToken cancellationToken)
  {
    TeacherEntity teacher = await _teacherService.FindTeacherById(teacherId);
    TeacherEntity deletedTeacher = await _teacherService.DeleteTeacher(teacher, cancellationToken);
    TeacherResponse teacherResponse = _mapper.Map<TeacherResponse>(deletedTeacher);

    return Ok(teacherResponse);
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<TeacherResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<TeacherResponse> GetTeachers()
  {
    var teachers = _teacherService.GetTeachers();
    await foreach (TeacherEntity teacher in teachers)
      yield return _mapper.Map<TeacherResponse>(teacher);
  }

  [HttpGet("search/{subject}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<TeacherResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<TeacherResponse> GetTeachersBySubject(SubjectName subject)
  {
    var teachers = _teacherService.GetTeachersBySubject(subject);
    await foreach (TeacherEntity teacher in teachers)
      yield return _mapper.Map<TeacherResponse>(teacher);
  }

  [HttpGet("{teacherId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> FindTeacherById(Guid teacherId)
  {
    TeacherEntity teacher = await _teacherService.FindTeacherById(teacherId);

    return Ok(_mapper.Map<TeacherResponse>(teacher));
  }

  [HttpGet("hasAssociatedGrades/{teacherId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<bool> HasAssociatedGrades(Guid teacherId) => await _teacherService.HasAssociatedGrades(teacherId);
}

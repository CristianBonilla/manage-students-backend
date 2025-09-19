using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using AutoMapper;
using ManageStudents.API.Filters;
using ManageStudents.Contracts.DTO.Student;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Entities;

namespace ManageStudents.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[ServiceErrorExceptionFilter]
public class StudentController(IMapper _mapper, IStudentService _studentService) : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentResponse))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddStudent([FromBody] StudentRequest studentRequest, CancellationToken cancellationToken)
  {
    StudentEntity student = _mapper.Map<StudentEntity>(studentRequest);
    StudentEntity addedStudent = await _studentService.AddStudent(student, cancellationToken);
    StudentResponse studentResponse = _mapper.Map<StudentResponse>(addedStudent);

    return CreatedAtAction(nameof(AddStudent), studentResponse);
  }

  [HttpPut("{studentId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> UpdateStudent(Guid studentId, [FromBody] StudentRequest studentRequest, CancellationToken cancellationToken)
  {
    StudentEntity student = await _studentService.FindStudentById(studentId);
    StudentEntity updatedStudent = _mapper.Map(studentRequest, student);
    StudentResponse studentResponse = _mapper.Map<StudentResponse>(await _studentService.UpdateStudent(updatedStudent, cancellationToken));

    return Ok(studentResponse);
  }

  [HttpDelete("{studentId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> DeleteStudent(Guid studentId, CancellationToken cancellationToken)
  {
    StudentEntity student = await _studentService.FindStudentById(studentId);
    StudentEntity deletedStudent = await _studentService.DeleteStudent(student, cancellationToken);
    StudentResponse studentResponse = _mapper.Map<StudentResponse>(deletedStudent);

    return Ok(studentResponse);
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<StudentResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<StudentResponse> GetStudents()
  {
    var students = _studentService.GetStudents();
    await foreach (StudentEntity student in students)
      yield return _mapper.Map<StudentResponse>(student);
  }

  [HttpGet("except/{teacherId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<StudentResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public IActionResult GetStudentsExceptTeacherId(Guid teacherId)
  {
    var students = _studentService.GetStudentsExceptTeacherId(teacherId)
      .Select(_mapper.Map<StudentResponse>);

    return Ok(students);
  }

  [HttpGet("{studentId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> FindStudentById(Guid studentId)
  {
    StudentEntity student = await _studentService.FindStudentById(studentId);

    return Ok(_mapper.Map<StudentResponse>(student));
  }

  [HttpGet("hasAssociatedGrades/{studentId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<bool> HasAssociatedGrades(Guid studentId) => await _studentService.HasAssociatedGrades(studentId);
}

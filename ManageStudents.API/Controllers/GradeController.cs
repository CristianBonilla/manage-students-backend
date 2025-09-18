using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using AutoMapper;
using ManageStudents.API.Filters;
using ManageStudents.Contracts.DTO.Grade;
using ManageStudents.Contracts.Services;
using ManageStudents.Domain.Entities;

namespace ManageStudents.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
[Produces("application/json")]
[ServiceErrorExceptionFilter]
public class GradeController(IMapper _mapper, IGradeService _gradeService) : ControllerBase
{
  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GradeResponse))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> AddGrade([FromBody] GradeRequest gradeRequest, CancellationToken cancellationToken)
  {
    GradeEntity grade = _mapper.Map<GradeEntity>(gradeRequest);
    GradeEntity addedGrade = await _gradeService.AddGrade(grade, cancellationToken);
    GradeResponse gradeResponse = _mapper.Map<GradeResponse>(addedGrade);

    return Ok(gradeResponse);
  }

  [HttpPut("{gradeId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> UpdateGrade(Guid gradeId, [FromBody] GradeRequest gradeRequest, CancellationToken cancellationToken)
  {
    GradeEntity grade = await _gradeService.FindGradeById(gradeId);
    GradeEntity updatedGrade = _mapper.Map(gradeRequest, grade);
    GradeResponse gradeResponse = _mapper.Map<GradeResponse>(await _gradeService.UpdateGrade(updatedGrade, cancellationToken));

    return Ok(gradeResponse);
  }

  [HttpDelete]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> DeleteGrade(Guid gradeId, CancellationToken cancellationToken)
  {
    GradeEntity grade = await _gradeService.FindGradeById(gradeId);
    GradeEntity deletedGrade = await _gradeService.DeleteGrade(grade, cancellationToken);
    GradeResponse gradeResponse = _mapper.Map<GradeResponse>(deletedGrade);

    return Ok(gradeResponse);
  }

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<GradeResponse>))]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async IAsyncEnumerable<GradeResponse> GetGrades()
  {
    var grades = _gradeService.GetGrades();
    await foreach (GradeEntity grade in grades)
      yield return _mapper.Map<GradeResponse>(grade);
  }

  [HttpGet("{gradeId}")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GradeResponse))]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> FindGradeById(Guid gradeId)
  {
    GradeEntity grade = await _gradeService.FindGradeById(gradeId);

    return Ok(_mapper.Map<GradeResponse>(grade));
  }
}

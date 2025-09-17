using ManageStudents.Contracts.SeedData;
using ManageStudents.Domain.Entities;

namespace ManageStudents.Domain.SeedWork.Collections;

class GradeCollection : SeedDataCollection<GradeEntity>
{
  readonly TeacherCollection _teachers = AllCollections.Teachers;
  readonly StudentCollection _students = AllCollections.Students;

  protected override GradeEntity[] Collection => [
    new()
    {
      GradeId = new("{ab8d7d96-e41a-4ede-8c19-2561d091ed5c}"),
      TeacherId = _teachers[0].TeacherId,
      StudentId = _students[0].StudentId,
      Value = 4.7F
    },
    new()
    {
      GradeId = new("{729617e4-7a24-433e-ae7f-c7fa36e80a1b}"),
      TeacherId = _teachers[1].TeacherId,
      StudentId = _students[0].StudentId,
      Value = 5.0F
    },
    new()
    {
      GradeId = new("{e3e942da-ce8d-41ac-973c-3bcaf848646f}"),
      TeacherId = _teachers[2].TeacherId,
      StudentId = _students[1].StudentId,
      Value = 3.1F
    },
    new()
    {
      GradeId = new("{178a3671-dd4e-451d-ab7e-65897a78997d}"),
      TeacherId = _teachers[3].TeacherId,
      StudentId = _students[1].StudentId,
      Value = 2.8F
    },
    new()
    {
      GradeId = new("{d3960faa-ca0b-457b-ae0e-2dc5b5e53abd}"),
      TeacherId = _teachers[0].TeacherId,
      StudentId = _students[2].StudentId,
      Value = 4.1F
    },
    new()
    {
      GradeId = new("{0655b98d-8437-4a63-be12-b172c869b6a3}"),
      TeacherId = _teachers[3].TeacherId,
      StudentId = _students[2].StudentId,
      Value = 4.6F
    },
    new()
    {
      GradeId = new("{31e9714a-a075-493c-9774-d29653968859}"),
      TeacherId = _teachers[4].TeacherId,
      StudentId = _students[3].StudentId,
      Value = 3.2F
    },
    new()
    {
      GradeId = new("{bfc36aea-6078-4f9e-832c-8e50c37c5599}"),
      TeacherId = _teachers[2].TeacherId,
      StudentId = _students[3].StudentId,
      Value = 4.3F
    }
  ];
}

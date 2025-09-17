using System.ComponentModel;

namespace ManageStudents.Domain.Entities.Enums;

public enum SubjectNames
{
  [Description("Matemáticas")]
  Mathematics = 1,
  [Description("Español")]
  Spanish = 2,
  [Description("Biología")]
  Biology = 3,
  [Description("Física")]
  Physics = 4,
  [Description("Química")]
  Chemistry = 5,
  [Description("Ciencias Políticas")]
  PoliticalScience = 6,
  [Description("Educación Física")]
  PhysicalEducation = 7
}

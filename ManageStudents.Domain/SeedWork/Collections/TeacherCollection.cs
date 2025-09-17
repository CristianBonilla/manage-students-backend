using ManageStudents.Contracts.SeedData;
using ManageStudents.Domain.Entities;
using ManageStudents.Domain.Entities.Enums;

namespace ManageStudents.Domain.SeedWork.Collections;

class TeacherCollection : SeedDataCollection<TeacherEntity>
{
  protected override TeacherEntity[] Collection => [
    new()
    {
      TeacherId = new("{8a05ac05-874c-4613-b29e-6fcd8feac250}"),
      DocumentNumber = "9831047265",
      Mobile = "3007123845",
      Firstname = "Ana",
      Lastname = "Pineda",
      Email = "ana.pineda@demo.edu",
      SubjectName = SubjectNames.Mathematics
    },
    new()
    {
      TeacherId = new("{ec5598c7-d66e-4197-ba2b-ba75d31c7227}"),
      DocumentNumber = "1203984756",
      Mobile = "3019837264",
      Firstname = "Luis",
      Lastname = "Montoya",
      Email = "luis.montoya@demo.edu",
      SubjectName = SubjectNames.Spanish
    },
    new()
    {
      TeacherId = new("{c9dbbc9c-cff7-45f8-8578-dedd939aa239}"),
      DocumentNumber = "6572039184",
      Mobile = "3021749382",
      Firstname = "Claudia",
      Lastname = "Herrera",
      Email = "claudia.herrera@demo.edu",
      SubjectName = SubjectNames.Biology
    },
    new()
    {
      TeacherId = new("{44d3a8bf-a043-4587-a642-c4905c775e70}"),
      DocumentNumber = "3049182736",
      Mobile = "3048261937",
      Firstname = "Jorge",
      Lastname = "Valencia",
      Email = "jorge.valencia@demo.edu",
      SubjectName = SubjectNames.PoliticalScience
    },
    new()
    {
      TeacherId = new("{bc6d7998-128e-4e30-afa9-6aa7a3af9b85}"),
      DocumentNumber = "8493027165",
      Mobile = "3059172836",
      Firstname = "Marcela",
      Lastname = "Cruz",
      Email = "marcela.cruz@demo.edu",
      SubjectName = SubjectNames.Chemistry
    },
    new()
    {
      TeacherId = new("{4e6b055a-4699-4c61-a476-f2a98f23cc54}"),
      DocumentNumber = "7102938465",
      Mobile = "3103847261",
      Firstname = "Ricardo",
      Lastname = "Salinas",
      Email = "ricardo.salinas@demo.edu",
      SubjectName = SubjectNames.Physics
    },
    new()
    {
      TeacherId = new("{2356f96f-fa55-4b35-86c9-4dcbc0d04924}"),
      DocumentNumber = "5928371046",
      Mobile = "3119283746",
      Firstname = "Patricia",
      Lastname = "Mora",
      Email = "patricia.mora@demo.edu",
      SubjectName = SubjectNames.PhysicalEducation
    },
    new()
    {
      TeacherId = new("{e81bfaa9-dc56-4703-b3dd-1564fc21d33a}"),
      DocumentNumber = "4382910675",
      Mobile = "3126471938",
      Firstname = "Fernando",
      Lastname = "García",
      Email = "fernando.garcia@demo.edu",
      SubjectName = SubjectNames.Mathematics
    },
    new()
    {
      TeacherId = new("{e41385d8-e050-4ac3-a924-c3237731dace}"),
      DocumentNumber = "6293847102",
      Mobile = "3138294750",
      Firstname = "Sandra",
      Lastname = "Luna",
      Email = "sandra.luna@demo.edu",
      SubjectName = SubjectNames.Chemistry
    },
    new()
    {
      TeacherId = new("{686692a7-2cbc-42c9-97b1-f99cdc454edb}"),
      DocumentNumber = "3759102846",
      Mobile = "3147382916",
      Firstname = "Héctor",
      Lastname = "Ruiz",
      Email = "hector.ruiz@demo.edu",
      SubjectName = SubjectNames.Physics
    }
  ];
}

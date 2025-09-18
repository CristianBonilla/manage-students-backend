using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageStudents.Infrastructure.Contexts.ManageStudents.Migrations;

/// <inheritdoc />
public partial class CreateTeacher : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.EnsureSchema(
        name: "dbo");

    migrationBuilder.CreateTable(
        name: "Teacher",
        schema: "dbo",
        columns: table => new
        {
          DocumentNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
          Mobile = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
          Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
          Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
          Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
          Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
          CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
          UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
          Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
          TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()")
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Teacher", x => x.TeacherId);
        });

    migrationBuilder.InsertData(
        schema: "dbo",
        table: "Teacher",
        columns: new[] { "TeacherId", "DocumentNumber", "Email", "Firstname", "Lastname", "Mobile", "Subject" },
        values: new object[,]
        {
                  { new Guid("2356f96f-fa55-4b35-86c9-4dcbc0d04924"), "5928371046", "patricia.mora@demo.edu", "Patricia", "Mora", "3119283746", "PhysicalEducation" },
                  { new Guid("44d3a8bf-a043-4587-a642-c4905c775e70"), "3049182736", "jorge.valencia@demo.edu", "Jorge", "Valencia", "3048261937", "PoliticalScience" },
                  { new Guid("4e6b055a-4699-4c61-a476-f2a98f23cc54"), "7102938465", "ricardo.salinas@demo.edu", "Ricardo", "Salinas", "3103847261", "Physics" },
                  { new Guid("686692a7-2cbc-42c9-97b1-f99cdc454edb"), "3759102846", "hector.ruiz@demo.edu", "Héctor", "Ruiz", "3147382916", "Physics" },
                  { new Guid("8a05ac05-874c-4613-b29e-6fcd8feac250"), "9831047265", "ana.pineda@demo.edu", "Ana", "Pineda", "3007123845", "Mathematics" },
                  { new Guid("bc6d7998-128e-4e30-afa9-6aa7a3af9b85"), "8493027165", "marcela.cruz@demo.edu", "Marcela", "Cruz", "3059172836", "Chemistry" },
                  { new Guid("c9dbbc9c-cff7-45f8-8578-dedd939aa239"), "6572039184", "claudia.herrera@demo.edu", "Claudia", "Herrera", "3021749382", "Biology" },
                  { new Guid("e41385d8-e050-4ac3-a924-c3237731dace"), "6293847102", "sandra.luna@demo.edu", "Sandra", "Luna", "3138294750", "Chemistry" },
                  { new Guid("e81bfaa9-dc56-4703-b3dd-1564fc21d33a"), "4382910675", "fernando.garcia@demo.edu", "Fernando", "García", "3126471938", "Mathematics" },
                  { new Guid("ec5598c7-d66e-4197-ba2b-ba75d31c7227"), "1203984756", "luis.montoya@demo.edu", "Luis", "Montoya", "3019837264", "Spanish" }
        });

    migrationBuilder.CreateIndex(
        name: "IX_Teacher_DocumentNumber_Mobile_Email",
        schema: "dbo",
        table: "Teacher",
        columns: new[] { "DocumentNumber", "Mobile", "Email" },
        unique: true);
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Teacher",
        schema: "dbo");
  }
}

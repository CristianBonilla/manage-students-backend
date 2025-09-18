using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageStudents.Infrastructure.Contexts.ManageStudents.Migrations;

/// <inheritdoc />
public partial class CreateGrade : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Grade",
        schema: "dbo",
        columns: table => new
        {
          Value = table.Column<float>(type: "real", nullable: false),
          CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
          UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
          Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
          GradeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
          TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
          StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Grade", x => x.GradeId);
          table.ForeignKey(
                    name: "FK_Grade_Student_StudentId",
                    column: x => x.StudentId,
                    principalSchema: "dbo",
                    principalTable: "Student",
                    principalColumn: "StudentId",
                    onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
                    name: "FK_Grade_Teacher_TeacherId",
                    column: x => x.TeacherId,
                    principalSchema: "dbo",
                    principalTable: "Teacher",
                    principalColumn: "TeacherId",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.InsertData(
        schema: "dbo",
        table: "Grade",
        columns: new[] { "GradeId", "StudentId", "TeacherId", "Value" },
        values: new object[,]
        {
                  { new Guid("0655b98d-8437-4a63-be12-b172c869b6a3"), new Guid("2942cb83-78f5-47d0-bf5b-7afc902da439"), new Guid("44d3a8bf-a043-4587-a642-c4905c775e70"), 4.6f },
                  { new Guid("178a3671-dd4e-451d-ab7e-65897a78997d"), new Guid("41133742-0044-4ca8-bdc8-95ed7f82ec49"), new Guid("44d3a8bf-a043-4587-a642-c4905c775e70"), 2.8f },
                  { new Guid("31e9714a-a075-493c-9774-d29653968859"), new Guid("650da35f-27a7-4e0a-8f27-f474da063fa1"), new Guid("bc6d7998-128e-4e30-afa9-6aa7a3af9b85"), 3.2f },
                  { new Guid("729617e4-7a24-433e-ae7f-c7fa36e80a1b"), new Guid("65ecd151-b88f-4d34-bf53-40bc70c0114d"), new Guid("ec5598c7-d66e-4197-ba2b-ba75d31c7227"), 5f },
                  { new Guid("ab8d7d96-e41a-4ede-8c19-2561d091ed5c"), new Guid("65ecd151-b88f-4d34-bf53-40bc70c0114d"), new Guid("8a05ac05-874c-4613-b29e-6fcd8feac250"), 4.7f },
                  { new Guid("bfc36aea-6078-4f9e-832c-8e50c37c5599"), new Guid("650da35f-27a7-4e0a-8f27-f474da063fa1"), new Guid("c9dbbc9c-cff7-45f8-8578-dedd939aa239"), 4.3f },
                  { new Guid("d3960faa-ca0b-457b-ae0e-2dc5b5e53abd"), new Guid("2942cb83-78f5-47d0-bf5b-7afc902da439"), new Guid("8a05ac05-874c-4613-b29e-6fcd8feac250"), 4.1f },
                  { new Guid("e3e942da-ce8d-41ac-973c-3bcaf848646f"), new Guid("41133742-0044-4ca8-bdc8-95ed7f82ec49"), new Guid("c9dbbc9c-cff7-45f8-8578-dedd939aa239"), 3.1f }
        });

    migrationBuilder.CreateIndex(
        name: "IX_Grade_StudentId",
        schema: "dbo",
        table: "Grade",
        column: "StudentId");

    migrationBuilder.CreateIndex(
        name: "IX_Grade_TeacherId_StudentId",
        schema: "dbo",
        table: "Grade",
        columns: new[] { "TeacherId", "StudentId" });
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Grade",
        schema: "dbo");
  }
}

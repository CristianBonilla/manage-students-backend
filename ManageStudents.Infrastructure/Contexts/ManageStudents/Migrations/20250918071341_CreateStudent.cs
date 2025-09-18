using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManageStudents.Infrastructure.Contexts.ManageStudents.Migrations;

/// <inheritdoc />
public partial class CreateStudent : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Student",
        schema: "dbo",
        columns: table => new
        {
          DocumentNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
          Mobile = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
          Firstname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
          Lastname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
          Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
          CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
          UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
          Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
          StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()")
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Student", x => x.StudentId);
        });

    migrationBuilder.InsertData(
        schema: "dbo",
        table: "Student",
        columns: new[] { "StudentId", "DocumentNumber", "Email", "Firstname", "Lastname", "Mobile" },
        values: new object[,]
        {
                  { new Guid("0112dba6-8437-46e4-a7e9-24d48d88f57b"), "3859201746", "julian.mejia@demo.edu", "Julián", "Mejía", "3238472037" },
                  { new Guid("0a5f090d-c8af-4721-a98d-9fd4ee998cd5"), "9847201938", "miguel.castro@demo.edu", "Miguel", "Castro", "3057382910" },
                  { new Guid("0d8b8543-a59d-4048-b314-15db7386b8fd"), "6172039485", "camila.rojas@demo.edu", "Camila", "Rojas", "3109283746" },
                  { new Guid("19427288-4e69-403d-84dc-24ed56672f75"), "2958371046", "isabela.cardenas@demo.edu", "Isabela", "Cárdenas", "3127381928" },
                  { new Guid("2942cb83-78f5-47d0-bf5b-7afc902da439"), "5610928374", "sofia.martinez@demo.edu", "Sofía", "Martínez", "3027381920" },
                  { new Guid("41133742-0044-4ca8-bdc8-95ed7f82ec49"), "3948271056", "carlos.ramirez@demo.edu", "Carlos", "Ramírez", "3018472938" },
                  { new Guid("4c16254c-0b81-4a90-a54d-e4701b6e0727"), "7592837461", "mateo.jimenez@demo.edu", "Mateo", "Jiménez", "3178472038" },
                  { new Guid("55e75efe-44ca-4308-8827-9ac95aaf29eb"), "6819203745", "gabriela.ortiz@demo.edu", "Gabriela", "Ortiz", "3208291737" },
                  { new Guid("608b4a71-658f-40fd-87ab-1ae29cc01b45"), "4301928475", "juan.moreno@demo.edu", "Juan", "Moreno", "3118472039" },
                  { new Guid("650da35f-27a7-4e0a-8f27-f474da063fa1"), "7083946152", "andres.torres@demo.edu", "Andrés", "Torres", "3039182746" },
                  { new Guid("65ecd151-b88f-4d34-bf53-40bc70c0114d"), "8721049385", "laura.gomez@demo.edu", "Laura", "Gómez", "3009182736" },
                  { new Guid("69c8eaf4-f08a-4b07-970b-d728c79584d6"), "6203948172", "lucia.pena@demo.edu", "Lucía", "Peña", "3169283745" },
                  { new Guid("6de4e016-291d-4f6d-954b-ca889d2b04e5"), "2398471056", "valentina.lopez@demo.edu", "Valentina", "López", "3048291736" },
                  { new Guid("93beaedd-686c-4e2a-9cf1-1cc6778949a3"), "3029481756", "felipe.navarro@demo.edu", "Felipe", "Navarro", "3199182739" },
                  { new Guid("a156ce94-516a-44ae-9efa-f2c37804a4e5"), "4938271059", "diego.mendoza@demo.edu", "Diego", "Mendoza", "3217382915" },
                  { new Guid("ad5db6a1-2ba7-44c5-91ef-fe484907e4ba"), "9182736450", "daniela.reyes@demo.edu", "Daniela", "Reyes", "3148291738" },
                  { new Guid("cf5057b1-1b50-4095-b227-7544adb8c9c9"), "3748291056", "tomas.gutierrez@demo.edu", "Tomás", "Gutiérrez", "3157382916" },
                  { new Guid("ef766d96-3a36-47d5-9f7c-2b14b7a0fbae"), "8037461925", "sebastian.vargas@demo.edu", "Sebastián", "Vargas", "3139182730" },
                  { new Guid("f0493ab5-325c-46a3-9969-e81b6247f4bc"), "7203846159", "paula.salazar@demo.edu", "Paula", "Salazar", "3229283747" },
                  { new Guid("f22e7be2-53a2-443e-8080-3a2311b928b9"), "8461928375", "mariana.suarez@demo.edu", "Mariana", "Suárez", "3187381927" }
        });

    migrationBuilder.CreateIndex(
        name: "IX_Student_DocumentNumber_Mobile_Email",
        schema: "dbo",
        table: "Student",
        columns: new[] { "DocumentNumber", "Mobile", "Email" },
        unique: true);
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Student",
        schema: "dbo");
  }
}

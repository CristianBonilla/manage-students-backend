using ManageStudents.Contracts.SeedData;
using ManageStudents.Domain.Entities;

namespace ManageStudents.Domain.SeedWork.Collections;

class StudentCollection : SeedDataCollection<StudentEntity>
{
  protected override StudentEntity[] Collection => [
    new()
    {
        StudentId = new("{65ecd151-b88f-4d34-bf53-40bc70c0114d}"),
        DocumentNumber = "8721049385",
        Mobile = "3009182736",
        Firstname = "Laura",
        Lastname = "Gómez",
        Email = "laura.gomez@demo.edu"
    },
    new()
    {
        StudentId = new("{41133742-0044-4ca8-bdc8-95ed7f82ec49}"),
        DocumentNumber = "3948271056",
        Mobile = "3018472938",
        Firstname = "Carlos",
        Lastname = "Ramírez",
        Email = "carlos.ramirez@demo.edu"
    },
    new()
    {
        StudentId = new("{2942cb83-78f5-47d0-bf5b-7afc902da439}"),
        DocumentNumber = "5610928374",
        Mobile = "3027381920",
        Firstname = "Sofía",
        Lastname = "Martínez",
        Email = "sofia.martinez@demo.edu"
    },
    new()
    {
        StudentId = new("{650da35f-27a7-4e0a-8f27-f474da063fa1}"),
        DocumentNumber = "7083946152",
        Mobile = "3039182746",
        Firstname = "Andrés",
        Lastname = "Torres",
        Email = "andres.torres@demo.edu"
    },
    new()
    {
        StudentId = new("{6de4e016-291d-4f6d-954b-ca889d2b04e5}"),
        DocumentNumber = "2398471056",
        Mobile = "3048291736",
        Firstname = "Valentina",
        Lastname = "López",
        Email = "valentina.lopez@demo.edu"
    },
    new()
    {
        StudentId = new("{0a5f090d-c8af-4721-a98d-9fd4ee998cd5}"),
        DocumentNumber = "9847201938",
        Mobile = "3057382910",
        Firstname = "Miguel",
        Lastname = "Castro",
        Email = "miguel.castro@demo.edu"
    },
    new()
    {
        StudentId = new("{0d8b8543-a59d-4048-b314-15db7386b8fd}"),
        DocumentNumber = "6172039485",
        Mobile = "3109283746",
        Firstname = "Camila",
        Lastname = "Rojas",
        Email = "camila.rojas@demo.edu"
    },
    new()
    {
        StudentId = new("{608b4a71-658f-40fd-87ab-1ae29cc01b45}"),
        DocumentNumber = "4301928475",
        Mobile = "3118472039",
        Firstname = "Juan",
        Lastname = "Moreno",
        Email = "juan.moreno@demo.edu"
    },
    new()
    {
        StudentId = new("{19427288-4e69-403d-84dc-24ed56672f75}"),
        DocumentNumber = "2958371046",
        Mobile = "3127381928",
        Firstname = "Isabela",
        Lastname = "Cárdenas",
        Email = "isabela.cardenas@demo.edu"
    },
    new()
    {
        StudentId = new("{ef766d96-3a36-47d5-9f7c-2b14b7a0fbae}"),
        DocumentNumber = "8037461925",
        Mobile = "3139182730",
        Firstname = "Sebastián",
        Lastname = "Vargas",
        Email = "sebastian.vargas@demo.edu"
    },
    new()
    {
        StudentId = new("{ad5db6a1-2ba7-44c5-91ef-fe484907e4ba}"),
        DocumentNumber = "9182736450",
        Mobile = "3148291738",
        Firstname = "Daniela",
        Lastname = "Reyes",
        Email = "daniela.reyes@demo.edu"
    },
    new()
    {
        StudentId = new("{cf5057b1-1b50-4095-b227-7544adb8c9c9}"),
        DocumentNumber = "3748291056",
        Mobile = "3157382916",
        Firstname = "Tomás",
        Lastname = "Gutiérrez",
        Email = "tomas.gutierrez@demo.edu"
    },
    new()
    {
        StudentId = new("{69c8eaf4-f08a-4b07-970b-d728c79584d6}"),
        DocumentNumber = "6203948172",
        Mobile = "3169283745",
        Firstname = "Lucía",
        Lastname = "Peña",
        Email = "lucia.pena@demo.edu"
    },
    new()
    {
        StudentId = new("{4c16254c-0b81-4a90-a54d-e4701b6e0727}"),
        DocumentNumber = "7592837461",
        Mobile = "3178472038",
        Firstname = "Mateo",
        Lastname = "Jiménez",
        Email = "mateo.jimenez@demo.edu"
    },
    new()
    {
        StudentId = new("{f22e7be2-53a2-443e-8080-3a2311b928b9}"),
        DocumentNumber = "8461928375",
        Mobile = "3187381927",
        Firstname = "Mariana",
        Lastname = "Suárez",
        Email = "mariana.suarez@demo.edu"
    },
    new()
    {
        StudentId = new("{93beaedd-686c-4e2a-9cf1-1cc6778949a3}"),
        DocumentNumber = "3029481756",
        Mobile = "3199182739",
        Firstname = "Felipe",
        Lastname = "Navarro",
        Email = "felipe.navarro@demo.edu"
    },
    new()
    {
        StudentId = new("{55e75efe-44ca-4308-8827-9ac95aaf29eb}"),
        DocumentNumber = "6819203745",
        Mobile = "3208291737",
        Firstname = "Gabriela",
        Lastname = "Ortiz",
        Email = "gabriela.ortiz@demo.edu"
    },
    new()
    {
        StudentId = new("{a156ce94-516a-44ae-9efa-f2c37804a4e5}"),
        DocumentNumber = "4938271059",
        Mobile = "3217382915",
        Firstname = "Diego",
        Lastname = "Mendoza",
        Email = "diego.mendoza@demo.edu"
    },
    new()
    {
        StudentId = new("{f0493ab5-325c-46a3-9969-e81b6247f4bc}"),
        DocumentNumber = "7203846159",
        Mobile = "3229283747",
        Firstname = "Paula",
        Lastname = "Salazar",
        Email = "paula.salazar@demo.edu"
    },
    new()
    {
        StudentId = new("{0112dba6-8437-46e4-a7e9-24d48d88f57b}"),
        DocumentNumber = "3859201746",
        Mobile = "3238472037",
        Firstname = "Julián",
        Lastname = "Mejía",
        Email = "julian.mejia@demo.edu"
    }
  ];
}

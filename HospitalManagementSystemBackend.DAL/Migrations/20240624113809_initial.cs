using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystemBackend.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaOfSpecialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Expiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientToken_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientToken_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientScript",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientTokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiseaseDiagnosed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientScript", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientScript_PatientToken_PatientTokenId",
                        column: x => x.PatientTokenId,
                        principalTable: "PatientToken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientScriptMedicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientScriptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientScriptId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientScriptMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientScriptMedicine_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientScriptMedicine_PatientScript_PatientScriptId",
                        column: x => x.PatientScriptId,
                        principalTable: "PatientScript",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "GenderName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Male" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Female" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Others." }
                });

            migrationBuilder.InsertData(
                table: "Medicine",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0eaa11d6-4875-4312-9e12-9d3691c5777f"), "Morphine" },
                    { new Guid("0ff11569-5654-49d6-80c7-41278461fa86"), "Metformin" },
                    { new Guid("1202644d-a4e3-4c8a-8231-ef7f8d301cfa"), "Warfarin" },
                    { new Guid("213b1942-6277-4664-b508-8eac370c9f02"), "Amoxicillin" },
                    { new Guid("30556c41-88b7-4fac-a465-eb1d6864f6b6"), "Albuterol" },
                    { new Guid("3212a800-cf55-413d-a4f3-58aeb5ef7bb3"), "Ibuprofen" },
                    { new Guid("380560f0-8da6-4ab0-bf8f-7f13b7ed1ffc"), "Paracetamol" },
                    { new Guid("44d29933-054c-48b2-bea3-074813a21c2b"), "Fluoxetine" },
                    { new Guid("693fa0fb-f500-48bf-ad87-3beda10b87a6"), "Simvastatin" },
                    { new Guid("7695536c-e3d5-4284-8942-1c6746b7f339"), "Omeprazole" },
                    { new Guid("782d006b-db4e-41f6-9248-5b8470a564d9"), "Prednisone" },
                    { new Guid("a0a3113a-b58b-4c9a-b9bf-eecb55710618"), "Amlodipine" },
                    { new Guid("a116134f-928f-4678-877b-931ba8bedbe1"), "Diazepam" },
                    { new Guid("c9e13b99-1667-48cb-b534-7bcc820f13ea"), "Hydrochlorothiazide" },
                    { new Guid("f8725d7d-3509-496c-8bda-49082ef1cb50"), "Loratadine" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "Age", "AreaOfSpecialization", "CNIC", "DateOfBirth", "Discriminator", "FName", "GenderId", "LName", "MobileNo" },
                values: new object[,]
                {
                    { new Guid("1a8fc091-442a-460e-8468-4829705e0874"), "567 Cedar St, City", 42, "Dermatology", "12345-678905", new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "David", new Guid("22222222-2222-2222-2222-222222222222"), "Brown", "123456785" },
                    { new Guid("3298cb2d-2bac-41b7-badc-8997a33fc87f"), "456 Elm St, City", 40, "Orthopedics", "12345-678902", new DateTime(1984, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Emily", new Guid("22222222-2222-2222-2222-222222222222"), "Smith", "123456782" },
                    { new Guid("4737db8d-c459-45df-9f31-7db7358b9c57"), "123 Main St, City", 35, "Cardiology", "12345-678901", new DateTime(1989, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "John", new Guid("11111111-1111-1111-1111-111111111111"), "Doe", "123456781" },
                    { new Guid("60829261-8a6c-4e19-91c0-1d46472e107d"), "890 Maple St, City", 37, "Oncology", "12345-678906", new DateTime(1987, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Jennifer", new Guid("33333333-3333-3333-3333-333333333333"), "Lee", "123456786" },
                    { new Guid("e75dfae2-1bbf-430a-8b92-6910977b43c6"), "234 Pine St, City", 38, "Pediatrics", "12345-678904", new DateTime(1986, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Sarah", new Guid("11111111-1111-1111-1111-111111111111"), "Williams", "123456784" },
                    { new Guid("fe6e1c48-f484-4796-b261-81edab9fef3d"), "789 Oak St, City", 45, "Neurology", "12345-678903", new DateTime(1979, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Michael", new Guid("33333333-3333-3333-3333-333333333333"), "Johnson", "123456783" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientScript_PatientTokenId",
                table: "PatientScript",
                column: "PatientTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScriptMedicine_MedicineId",
                table: "PatientScriptMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScriptMedicine_PatientScriptId",
                table: "PatientScriptMedicine",
                column: "PatientScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToken_DoctorId",
                table: "PatientToken",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToken_PatientId",
                table: "PatientToken",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_GenderId",
                table: "Person",
                column: "GenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientScriptMedicine");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "PatientScript");

            migrationBuilder.DropTable(
                name: "PatientToken");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}

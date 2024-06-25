using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystemBackend.DAL.Migrations
{
    public partial class patient_token_new_column_token : Migration
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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    { new Guid("03c85095-c976-43f3-aa1e-294e704147fc"), "Amoxicillin" },
                    { new Guid("0920bdc0-62dd-425c-9e5c-09baf7d1607e"), "Diazepam" },
                    { new Guid("27355d7c-02fe-4254-a997-bdac889a94ff"), "Warfarin" },
                    { new Guid("2ad8b7b6-4f0e-4f0b-815c-582aed90727f"), "Fluoxetine" },
                    { new Guid("3204524c-827c-4c02-b64a-0f27feff5c68"), "Paracetamol" },
                    { new Guid("343f8fe6-f45d-42d4-b3fd-56c9dc003a79"), "Omeprazole" },
                    { new Guid("8f097174-d4ad-4e7a-a31f-38c046ee0ea5"), "Amlodipine" },
                    { new Guid("94df7ffc-1281-4620-a64d-1c768b7c8df6"), "Ibuprofen" },
                    { new Guid("a39d7eae-b49c-4066-90f3-dd2c65f8819b"), "Albuterol" },
                    { new Guid("ab55f1f2-ad69-40f2-aa7f-07c92071b761"), "Morphine" },
                    { new Guid("bc14bb02-e299-4f6e-87ea-db63c8b4bef3"), "Hydrochlorothiazide" },
                    { new Guid("c76ed72a-e2e3-4dd9-87af-d36e0a127e66"), "Simvastatin" },
                    { new Guid("c8bdbd60-4d34-46fc-9367-0c676306b84c"), "Prednisone" },
                    { new Guid("d54f2c00-e4a8-4d8f-907e-805f278df8a9"), "Loratadine" },
                    { new Guid("fed1adc9-0778-494d-b2bf-cb257e13dd33"), "Metformin" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "Age", "AreaOfSpecialization", "CNIC", "DateOfBirth", "Discriminator", "FName", "GenderId", "LName", "MobileNo" },
                values: new object[,]
                {
                    { new Guid("0ec584f4-f945-44e0-a53c-dbf4adf91680"), "890 Maple St, City", 37, "Oncology", "12345-678906", new DateTime(1987, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Jennifer", new Guid("33333333-3333-3333-3333-333333333333"), "Lee", "123456786" },
                    { new Guid("412c2eaf-09ad-4daf-b3b0-a72f395fb630"), "456 Elm St, City", 40, "Orthopedics", "12345-678902", new DateTime(1984, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Emily", new Guid("22222222-2222-2222-2222-222222222222"), "Smith", "123456782" },
                    { new Guid("730e9aea-700c-40e5-8fe5-57211f9f68fe"), "567 Cedar St, City", 42, "Dermatology", "12345-678905", new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "David", new Guid("22222222-2222-2222-2222-222222222222"), "Brown", "123456785" },
                    { new Guid("7a491719-5e4c-4a66-b1d9-b329f6861c2c"), "234 Pine St, City", 38, "Pediatrics", "12345-678904", new DateTime(1986, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Sarah", new Guid("11111111-1111-1111-1111-111111111111"), "Williams", "123456784" },
                    { new Guid("a2be6b28-5009-41f7-b017-89b553555ad9"), "123 Main St, City", 35, "Cardiology", "12345-678901", new DateTime(1989, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "John", new Guid("11111111-1111-1111-1111-111111111111"), "Doe", "123456781" },
                    { new Guid("be4e5bcf-3ff2-46b2-84db-a283d789f7a9"), "789 Oak St, City", 45, "Neurology", "12345-678903", new DateTime(1979, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Michael", new Guid("33333333-3333-3333-3333-333333333333"), "Johnson", "123456783" }
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

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
                    UpdatedTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientScript",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientDoctorTokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiseaseDiagnosed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientScript", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientScript_PatientToken_PatientDoctorTokenId",
                        column: x => x.PatientDoctorTokenId,
                        principalTable: "PatientToken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientScript_Person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Person",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientScript_Person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientScriptMedicine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientDoctorScriptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientDoctorScriptId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        name: "FK_PatientScriptMedicine_PatientScript_PatientDoctorScriptId",
                        column: x => x.PatientDoctorScriptId,
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
                    { new Guid("18bc1ddc-be12-4d62-b3f4-d981f62ea1a3"), "Fluoxetine" },
                    { new Guid("27ff31bf-5789-460b-a863-326beb671e82"), "Morphine" },
                    { new Guid("33a3b54a-beab-49ee-a956-539d22ca52f3"), "Amlodipine" },
                    { new Guid("3956b8ed-fed3-4014-b228-07cd637654c4"), "Paracetamol" },
                    { new Guid("4d3062f2-0059-48e9-943e-bc93effbfb08"), "Amoxicillin" },
                    { new Guid("4f337d3e-697b-4a7e-aa61-5144f5a66b47"), "Metformin" },
                    { new Guid("5f79d230-51f2-4b3d-a492-82e065328310"), "Simvastatin" },
                    { new Guid("8ddfaaed-473d-4d7f-90b4-543985e27bd7"), "Omeprazole" },
                    { new Guid("904ae690-717c-4083-afac-7485bdace557"), "Warfarin" },
                    { new Guid("a30038b5-0987-4b4d-9dc7-9f732f7fd5a6"), "Diazepam" },
                    { new Guid("a424f0dc-4f04-4638-a354-f79d5849e7e7"), "Hydrochlorothiazide" },
                    { new Guid("c4024b7b-7be2-4d4f-9b83-770b8fe78478"), "Prednisone" },
                    { new Guid("d47413fe-d7f6-4a7e-8bf6-3db297320456"), "Ibuprofen" },
                    { new Guid("e00eb757-a1d9-4d79-9ba5-227e531161e3"), "Loratadine" },
                    { new Guid("fb40ae30-08a5-4b10-8fe8-e047315bad07"), "Albuterol" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Address", "Age", "AreaOfSpecialization", "CNIC", "DateOfBirth", "Discriminator", "FName", "GenderId", "LName", "MobileNo" },
                values: new object[,]
                {
                    { new Guid("142e432d-5900-4acb-9cd0-2ff85aa3013a"), "789 Oak St, City", 45, "Neurology", "12345-678903", new DateTime(1979, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Michael", new Guid("33333333-3333-3333-3333-333333333333"), "Johnson", "123456783" },
                    { new Guid("36698093-43fd-4cd7-8d3f-923eba4de962"), "890 Maple St, City", 37, "Oncology", "12345-678906", new DateTime(1987, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Jennifer", new Guid("33333333-3333-3333-3333-333333333333"), "Lee", "123456786" },
                    { new Guid("7d757ee5-e68b-402a-b574-55a0b352de8d"), "456 Elm St, City", 40, "Orthopedics", "12345-678902", new DateTime(1984, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Emily", new Guid("22222222-2222-2222-2222-222222222222"), "Smith", "123456782" },
                    { new Guid("994565cd-1702-4202-a85e-99a4a6cb0465"), "123 Main St, City", 35, "Cardiology", "12345-678901", new DateTime(1989, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "John", new Guid("11111111-1111-1111-1111-111111111111"), "Doe", "123456781" },
                    { new Guid("9c1f583e-b03d-4b4d-8ca9-433eb008f54e"), "567 Cedar St, City", 42, "Dermatology", "12345-678905", new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "David", new Guid("22222222-2222-2222-2222-222222222222"), "Brown", "123456785" },
                    { new Guid("cffb1b14-8873-4a10-ba43-2b27a983ef88"), "234 Pine St, City", 38, "Pediatrics", "12345-678904", new DateTime(1986, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Sarah", new Guid("11111111-1111-1111-1111-111111111111"), "Williams", "123456784" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientScript_DoctorId",
                table: "PatientScript",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScript_PatientDoctorTokenId",
                table: "PatientScript",
                column: "PatientDoctorTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScript_PatientId",
                table: "PatientScript",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScriptMedicine_MedicineId",
                table: "PatientScriptMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientScriptMedicine_PatientDoctorScriptId",
                table: "PatientScriptMedicine",
                column: "PatientDoctorScriptId");

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

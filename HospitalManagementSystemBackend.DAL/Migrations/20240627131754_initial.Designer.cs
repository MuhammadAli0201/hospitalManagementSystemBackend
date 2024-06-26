﻿// <auto-generated />
using System;
using HospitalManagementSystemBackend.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagementSystemBackend.DAL.Migrations
{
    [DbContext(typeof(HMSDbContext))]
    [Migration("20240627131754_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            GenderName = "Male"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            GenderName = "Female"
                        },
                        new
                        {
                            Id = new Guid("33333333-3333-3333-3333-333333333333"),
                            GenderName = "Others."
                        });
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Medicine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicine");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3956b8ed-fed3-4014-b228-07cd637654c4"),
                            Name = "Paracetamol"
                        },
                        new
                        {
                            Id = new Guid("d47413fe-d7f6-4a7e-8bf6-3db297320456"),
                            Name = "Ibuprofen"
                        },
                        new
                        {
                            Id = new Guid("e00eb757-a1d9-4d79-9ba5-227e531161e3"),
                            Name = "Loratadine"
                        },
                        new
                        {
                            Id = new Guid("8ddfaaed-473d-4d7f-90b4-543985e27bd7"),
                            Name = "Omeprazole"
                        },
                        new
                        {
                            Id = new Guid("4d3062f2-0059-48e9-943e-bc93effbfb08"),
                            Name = "Amoxicillin"
                        },
                        new
                        {
                            Id = new Guid("5f79d230-51f2-4b3d-a492-82e065328310"),
                            Name = "Simvastatin"
                        },
                        new
                        {
                            Id = new Guid("4f337d3e-697b-4a7e-aa61-5144f5a66b47"),
                            Name = "Metformin"
                        },
                        new
                        {
                            Id = new Guid("904ae690-717c-4083-afac-7485bdace557"),
                            Name = "Warfarin"
                        },
                        new
                        {
                            Id = new Guid("fb40ae30-08a5-4b10-8fe8-e047315bad07"),
                            Name = "Albuterol"
                        },
                        new
                        {
                            Id = new Guid("18bc1ddc-be12-4d62-b3f4-d981f62ea1a3"),
                            Name = "Fluoxetine"
                        },
                        new
                        {
                            Id = new Guid("27ff31bf-5789-460b-a863-326beb671e82"),
                            Name = "Morphine"
                        },
                        new
                        {
                            Id = new Guid("a424f0dc-4f04-4638-a354-f79d5849e7e7"),
                            Name = "Hydrochlorothiazide"
                        },
                        new
                        {
                            Id = new Guid("33a3b54a-beab-49ee-a956-539d22ca52f3"),
                            Name = "Amlodipine"
                        },
                        new
                        {
                            Id = new Guid("c4024b7b-7be2-4d4f-9b83-770b8fe78478"),
                            Name = "Prednisone"
                        },
                        new
                        {
                            Id = new Guid("a30038b5-0987-4b4d-9dc7-9f732f7fd5a6"),
                            Name = "Diazepam"
                        });
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.PatientDoctorScript", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiseaseDiagnosed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientDoctorTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalBill")
                        .HasColumnType("int");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientDoctorTokenId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientScript");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.PatientDoctorScriptMedicine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientDoctorScriptId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientDoctorScriptId2")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PatientDoctorScriptId");

                    b.ToTable("PatientScriptMedicine");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.PatientDoctorToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedTimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientToken");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CNIC")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Doctor", b =>
                {
                    b.HasBaseType("HospitalManagementSystemBackend.Models.Models.Person");

                    b.Property<string>("AreaOfSpecialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Doctor");

                    b.HasData(
                        new
                        {
                            Id = new Guid("994565cd-1702-4202-a85e-99a4a6cb0465"),
                            Address = "123 Main St, City",
                            Age = 35,
                            CNIC = "12345-678901",
                            DateOfBirth = new DateTime(1989, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "John",
                            GenderId = new Guid("11111111-1111-1111-1111-111111111111"),
                            LName = "Doe",
                            MobileNo = "123456781",
                            AreaOfSpecialization = "Cardiology"
                        },
                        new
                        {
                            Id = new Guid("7d757ee5-e68b-402a-b574-55a0b352de8d"),
                            Address = "456 Elm St, City",
                            Age = 40,
                            CNIC = "12345-678902",
                            DateOfBirth = new DateTime(1984, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "Emily",
                            GenderId = new Guid("22222222-2222-2222-2222-222222222222"),
                            LName = "Smith",
                            MobileNo = "123456782",
                            AreaOfSpecialization = "Orthopedics"
                        },
                        new
                        {
                            Id = new Guid("142e432d-5900-4acb-9cd0-2ff85aa3013a"),
                            Address = "789 Oak St, City",
                            Age = 45,
                            CNIC = "12345-678903",
                            DateOfBirth = new DateTime(1979, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "Michael",
                            GenderId = new Guid("33333333-3333-3333-3333-333333333333"),
                            LName = "Johnson",
                            MobileNo = "123456783",
                            AreaOfSpecialization = "Neurology"
                        },
                        new
                        {
                            Id = new Guid("cffb1b14-8873-4a10-ba43-2b27a983ef88"),
                            Address = "234 Pine St, City",
                            Age = 38,
                            CNIC = "12345-678904",
                            DateOfBirth = new DateTime(1986, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "Sarah",
                            GenderId = new Guid("11111111-1111-1111-1111-111111111111"),
                            LName = "Williams",
                            MobileNo = "123456784",
                            AreaOfSpecialization = "Pediatrics"
                        },
                        new
                        {
                            Id = new Guid("9c1f583e-b03d-4b4d-8ca9-433eb008f54e"),
                            Address = "567 Cedar St, City",
                            Age = 42,
                            CNIC = "12345-678905",
                            DateOfBirth = new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "David",
                            GenderId = new Guid("22222222-2222-2222-2222-222222222222"),
                            LName = "Brown",
                            MobileNo = "123456785",
                            AreaOfSpecialization = "Dermatology"
                        },
                        new
                        {
                            Id = new Guid("36698093-43fd-4cd7-8d3f-923eba4de962"),
                            Address = "890 Maple St, City",
                            Age = 37,
                            CNIC = "12345-678906",
                            DateOfBirth = new DateTime(1987, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "Jennifer",
                            GenderId = new Guid("33333333-3333-3333-3333-333333333333"),
                            LName = "Lee",
                            MobileNo = "123456786",
                            AreaOfSpecialization = "Oncology"
                        });
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Patient", b =>
                {
                    b.HasBaseType("HospitalManagementSystemBackend.Models.Models.Person");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.PatientDoctorScript", b =>
                {
                    b.HasOne("HospitalManagementSystemBackend.Models.Models.Doctor", "Doctor")
                        .WithMany("PatientScripts")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystemBackend.Models.Models.PatientDoctorToken", "PatientDoctorToken")
                        .WithMany("PatientDoctorScripts")
                        .HasForeignKey("PatientDoctorTokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystemBackend.Models.Models.Patient", "Patient")
                        .WithMany("PatientDoctorScripts")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("PatientDoctorToken");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.PatientDoctorScriptMedicine", b =>
                {
                    b.HasOne("HospitalManagementSystemBackend.Models.Models.Medicine", "Medicine")
                        .WithMany("PatientScriptMedicines")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystemBackend.Models.Models.PatientDoctorScript", "PatientDoctorScript")
                        .WithMany("PatientScriptMedicines")
                        .HasForeignKey("PatientDoctorScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("PatientDoctorScript");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.PatientDoctorToken", b =>
                {
                    b.HasOne("HospitalManagementSystemBackend.Models.Models.Doctor", "Doctor")
                        .WithMany("PatientTokens")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HospitalManagementSystemBackend.Models.Models.Patient", "Patient")
                        .WithMany("PatientDoctorTokens")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Person", b =>
                {
                    b.HasOne("HospitalManagementSystemBackend.Models.Models.Gender", "Gender")
                        .WithMany("Persons")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Gender", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Medicine", b =>
                {
                    b.Navigation("PatientScriptMedicines");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.PatientDoctorScript", b =>
                {
                    b.Navigation("PatientScriptMedicines");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.PatientDoctorToken", b =>
                {
                    b.Navigation("PatientDoctorScripts");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Doctor", b =>
                {
                    b.Navigation("PatientScripts");

                    b.Navigation("PatientTokens");
                });

            modelBuilder.Entity("HospitalManagementSystemBackend.Models.Models.Patient", b =>
                {
                    b.Navigation("PatientDoctorScripts");

                    b.Navigation("PatientDoctorTokens");
                });
#pragma warning restore 612, 618
        }
    }
}

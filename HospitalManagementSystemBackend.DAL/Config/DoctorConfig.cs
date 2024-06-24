using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.DAL.Config
{
    internal class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(p => p.AreaOfSpecialization).IsRequired();

            builder.HasData(
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    FName = "John",
                    LName = "Doe",
                    Age = 35,
                    DateOfBirth = new DateTime(1989, 5, 15),
                    MobileNo = "123456781",
                    CNIC = "12345-678901",
                    Address = "123 Main St, City",
                    GenderId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    AreaOfSpecialization = "Cardiology"
                },
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    FName = "Emily",
                    LName = "Smith",
                    Age = 40,
                    DateOfBirth = new DateTime(1984, 9, 23),
                    MobileNo = "123456782",
                    CNIC = "12345-678902",
                    Address = "456 Elm St, City",
                    GenderId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    AreaOfSpecialization = "Orthopedics"
                },
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    FName = "Michael",
                    LName = "Johnson",
                    Age = 45,
                    DateOfBirth = new DateTime(1979, 3, 8),
                    MobileNo = "123456783",
                    CNIC = "12345-678903",
                    Address = "789 Oak St, City",
                    GenderId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    AreaOfSpecialization = "Neurology"
                },
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    FName = "Sarah",
                    LName = "Williams",
                    Age = 38,
                    DateOfBirth = new DateTime(1986, 7, 12),
                    MobileNo = "123456784",
                    CNIC = "12345-678904",
                    Address = "234 Pine St, City",
                    GenderId = Guid.Parse("11111111-1111-1111-1111-111111111111"), // Male
                    AreaOfSpecialization = "Pediatrics"
                },
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    FName = "David",
                    LName = "Brown",
                    Age = 42,
                    DateOfBirth = new DateTime(1982, 11, 30),
                    MobileNo = "123456785",
                    CNIC = "12345-678905",
                    Address = "567 Cedar St, City",
                    GenderId = Guid.Parse("22222222-2222-2222-2222-222222222222"), // Female
                    AreaOfSpecialization = "Dermatology"
                },
                new Doctor
                {
                    Id = Guid.NewGuid(),
                    FName = "Jennifer",
                    LName = "Lee",
                    Age = 37,
                    DateOfBirth = new DateTime(1987, 2, 18),
                    MobileNo = "123456786",
                    CNIC = "12345-678906",
                    Address = "890 Maple St, City",
                    GenderId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    AreaOfSpecialization = "Oncology"
                }
        );
        }
    }
}

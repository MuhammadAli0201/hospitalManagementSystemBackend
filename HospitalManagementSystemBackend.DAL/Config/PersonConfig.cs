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
    internal class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FName).IsRequired();
            builder.Property(p => p.LName).IsRequired();
            builder.Property(p => p.CNIC).IsRequired().HasMaxLength(13);
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.GenderId).IsRequired();
            builder.Property(p => p.MobileNo).IsRequired();
            builder.Property(p => p.DateOfBirth).IsRequired();
            builder.HasOne(p => p.Gender).WithMany(g => g.Persons).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}

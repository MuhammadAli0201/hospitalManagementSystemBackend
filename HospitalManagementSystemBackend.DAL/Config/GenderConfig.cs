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
    internal class GenderConfig : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.GenderName).IsRequired();
            builder.HasMany(g => g.Persons).WithOne(p => p.Gender).HasForeignKey(g => g.GenderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<Gender> {
            new Gender { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), GenderName = "Male" },
            new Gender { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), GenderName = "Female" },
            new Gender { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), GenderName = "Others." }
            });
        }
    }
}

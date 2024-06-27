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
    internal class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasMany(p => p.PatientDoctorTokens)
                .WithOne(pt => pt.Patient)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(d => d.PatientDoctorScripts)
                .WithOne(ps => ps.Patient)
                .HasForeignKey(ps => ps.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

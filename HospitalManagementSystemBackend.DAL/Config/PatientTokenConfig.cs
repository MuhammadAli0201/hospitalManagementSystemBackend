using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.DAL.Config
{
    internal class PatientTokenConfig : IEntityTypeConfiguration<PatientToken>
    {
        public void Configure(EntityTypeBuilder<PatientToken> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Expiry).IsRequired();

            builder.HasOne(pt => pt.Patient)
                .WithMany(p => p.PatientTokens)
                .HasForeignKey(pt => pt.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pt => pt.Doctor)
                .WithMany(p => p.PatientTokens)
                .HasForeignKey(pt => pt.DoctorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

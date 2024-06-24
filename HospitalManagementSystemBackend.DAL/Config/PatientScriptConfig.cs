using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.DAL.Config
{
    internal class PatientScriptConfig : IEntityTypeConfiguration<PatientScript>
    {
        public void Configure(EntityTypeBuilder<PatientScript> builder)
        {
            builder.HasKey(ps => ps.Id);
            builder.Property(ps => ps.VisitDate).IsRequired();
            builder.Property(ps => ps.DiseaseDiagnosed).IsRequired();
            builder.Property(ps => ps.TotalBill).IsRequired();

            builder.HasMany(ps => ps.PatientScriptMedicines)
                .WithOne()
                .HasForeignKey(pm => pm.PatientScriptId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ps => ps.PatientToken)
                .WithMany(p => p.PatientScripts)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

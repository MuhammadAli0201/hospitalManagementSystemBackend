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
    internal class PatientScriptMedicineConfig : IEntityTypeConfiguration<PatientScriptMedicine>
    {
        public void Configure(EntityTypeBuilder<PatientScriptMedicine> builder)
        {
            builder.HasKey(psm => psm.Id);
            builder.HasOne(psm => psm.PatientScript).WithMany(ps => ps.PatientScriptMedicines).HasForeignKey(psm => psm.PatientScriptId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(psm => psm.Medicine).WithMany(m => m.PatientScriptMedicines).HasForeignKey(psm => psm.MedicineId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

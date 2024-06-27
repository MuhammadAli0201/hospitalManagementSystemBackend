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
    internal class PatientDoctorScriptMedicineConfig : IEntityTypeConfiguration<PatientDoctorScriptMedicine>
    {
        public void Configure(EntityTypeBuilder<PatientDoctorScriptMedicine> builder)
        {
            builder.HasKey(psm => psm.Id);
            builder.HasOne(psm => psm.PatientDoctorScript).WithMany(ps => ps.PatientDoctorScriptMedicines).HasForeignKey(psm => psm.PatientDoctorScriptId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(psm => psm.Medicine).WithMany(m => m.PatientScriptMedicines).HasForeignKey(psm => psm.MedicineId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

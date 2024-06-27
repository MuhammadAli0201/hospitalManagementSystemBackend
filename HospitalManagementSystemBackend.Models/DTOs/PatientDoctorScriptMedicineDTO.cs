using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class PatientDoctorScriptMedicineDTO
    {
        public Guid Id { get; set; }
        public Guid PatientDoctorScriptId { get; set; }
        public Guid MedicineId { get; set; }
        public MedicineDTO Medicine { get; set; }

        public PatientDoctorScriptMedicine MapDTOToModel()
        {
            return new PatientDoctorScriptMedicine
            {
                Id = this.Id,
                PatientDoctorScriptId = this.PatientDoctorScriptId,
                MedicineId = this.MedicineId,
                Medicine = this.Medicine != null ? this.Medicine.MapDTOToModel() : null
            };
        }
    }
}

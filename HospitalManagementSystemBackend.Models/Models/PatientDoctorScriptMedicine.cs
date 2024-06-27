using HospitalManagementSystemBackend.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class PatientDoctorScriptMedicine
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(PatientDoctorScript))]
        public Guid PatientDoctorScriptId { get; set; }
        public PatientDoctorScript PatientDoctorScript { get; set; }

        [ForeignKey(nameof(Medicine))]
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public PatientDoctorScriptMedicineDTO MapModelToDTO()
        {
            return new PatientDoctorScriptMedicineDTO
            {
                Id = this.Id,
                PatientDoctorScriptId = this.PatientDoctorScriptId,
                MedicineId = this.MedicineId,
                Medicine = this.Medicine != null ? this.Medicine.MapModelToDTO() : null
            };
        }
    }
}

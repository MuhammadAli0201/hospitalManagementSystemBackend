using HospitalManagementSystemBackend.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class PatientScriptMedicine
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(PatientScript))]
        public Guid PatientScriptId { get; set; }
        public PatientScript PatientScript { get; set; }

        [ForeignKey(nameof(Medicine))]
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public PatientScriptMedicineDTO MapModelToDTO()
        {
            return new PatientScriptMedicineDTO
            {
                Id = this.Id,
                PatientScriptId = this.PatientScriptId,
                MedicineId = this.MedicineId,
            };
        }
    }
}

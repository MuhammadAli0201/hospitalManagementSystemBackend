using HospitalManagementSystemBackend.Models.DTOs;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PatientDoctorScriptMedicine> PatientScriptMedicines { get; set; }

        public MedicineDTO MapModelToDTO()
        {
            return new MedicineDTO
            {
                Id = this.Id,
                Name = this.Name,
            };
        }
    }
}

using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class PatientDoctorScriptDTO
    {
        public Guid Id { get; set; }
        public Guid PatientDoctorTokenId { get; set; }
        public PatientDoctorTokenDTO PatientDoctorToken { get; set; }
        public Guid PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public Guid DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public DateTime VisitDate { get; set; }
        public string DiseaseDiagnosed { get; set; }
        public int TotalBill { get; set; }
        public List<PatientDoctorScriptMedicineDTO> PatientDoctorScriptMedicines { get; set; }

        public PatientDoctorScript MapDTOToModel()
        {
            return new PatientDoctorScript
            {
                Id = this.Id,
                PatientDoctorTokenId = this.PatientDoctorTokenId,
                PatientDoctorToken = this.PatientDoctorToken != null ? this.PatientDoctorToken.MapDTOToModel() : null,
                VisitDate = this.VisitDate,
                DiseaseDiagnosed = this.DiseaseDiagnosed,
                TotalBill = this.TotalBill,
                PatientId=this.PatientId,
                Patient = this.Patient != null ? this.Patient.MapDTOToModel() : null,
                DoctorId=this.DoctorId,
                Doctor = this.Doctor != null ? this.Doctor.MapDTOToModel() : null,
                PatientDoctorScriptMedicines = this.PatientDoctorScriptMedicines.Select(psm => psm.MapDTOToModel()).ToList()
            };
        }
    }
}

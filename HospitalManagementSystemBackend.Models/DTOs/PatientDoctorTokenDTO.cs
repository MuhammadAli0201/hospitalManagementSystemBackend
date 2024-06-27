using HospitalManagementSystemBackend.Models.Enums;
using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class PatientDoctorTokenDTO
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public Guid DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public DateTime Expiry { get; set; }
        public PatientTokenExpiry Status { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }

        public PatientDoctorToken MapDTOToModel()
        {
            return new PatientDoctorToken
            {
                Id = Id,
                PatientId = PatientId,
                Patient = this.Patient != null ? Patient.MapDTOToModel() : null,
                DoctorId = DoctorId,
                Doctor = this.Doctor != null ? Doctor.MapDTOToModel() : null,
                Expiry = Expiry
            };
        }
    }
}

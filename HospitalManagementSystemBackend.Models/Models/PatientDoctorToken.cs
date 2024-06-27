using HospitalManagementSystemBackend.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class PatientDoctorToken
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        
        [ForeignKey(nameof(Doctor))]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }
        public List<PatientDoctorScript> PatientDoctorScripts { get; set; }

        public PatientDoctorTokenDTO MapModelToDTO()
        {
            return new PatientDoctorTokenDTO
            {
                Id = Id,
                PatientId = PatientId,
                UpdatedTimeStamp=UpdatedTimeStamp,
                Patient = this.Patient !=null? Patient.MapModelToDTO(): null,
                DoctorId = DoctorId,
                Doctor = this.Doctor != null ? Doctor.MapModelToDTO() : null,
                Expiry = Expiry,
            };
        }
    }
}

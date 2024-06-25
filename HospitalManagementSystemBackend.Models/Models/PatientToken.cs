using HospitalManagementSystemBackend.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class PatientToken
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        
        [ForeignKey(nameof(Doctor))]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Expiry { get; set; }
        public string Status { get; set; }
        public Guid Token { get; set; }
        public List<PatientScript> PatientScripts { get; set; }

        public PatientTokenDTO MapModelToDTO()
        {
            return new PatientTokenDTO
            {
                Id = Id,
                PatientId = PatientId,
                Token = Token,
                Patient = this.Patient !=null? Patient.MapModelToDTO(): null,
                DoctorId = DoctorId,
                Doctor = this.Doctor != null ? Doctor.MapModelToDTO() : null,
                Expiry = Expiry,
                Status = Status
            };
        }
    }
}

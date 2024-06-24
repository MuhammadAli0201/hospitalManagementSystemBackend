using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class PatientTokenDTO
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public Guid DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public DateTime Expiry { get; set; }
        public string Status { get; set; }

        public PatientToken MapDTOToModel()
        {
            return new PatientToken
            {
                Id = Id,
                PatientId = PatientId,
                Patient = this.Patient != null ? Patient.MapDTOToModel() : null,
                DoctorId = DoctorId,
                Doctor = this.Doctor != null ? Doctor.MapDTOToModel() : null,
                Expiry = Expiry,
                Status = Status
            };
        }
    }
}

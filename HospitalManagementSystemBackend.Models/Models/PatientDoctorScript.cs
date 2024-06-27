using HospitalManagementSystemBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class PatientDoctorScript
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(PatientDoctorToken))]
        public Guid PatientDoctorTokenId { get; set; }
        public PatientDoctorToken PatientDoctorToken { get; set; }

        [ForeignKey(nameof(Patient))]
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime VisitDate { get; set; }
        public string DiseaseDiagnosed { get; set; }
        public int TotalBill { get; set; }
        public List<PatientDoctorScriptMedicine> PatientDoctorScriptMedicines { get; set; }

        public PatientDoctorScriptDTO MapModelToDTO()
        {
            return new PatientDoctorScriptDTO
            {
                Id = this.Id,
                PatientDoctorTokenId = this.PatientDoctorTokenId,
                PatientDoctorToken = this.PatientDoctorToken != null ? this.PatientDoctorToken.MapModelToDTO() : null,
                VisitDate = this.VisitDate,
                DiseaseDiagnosed = this.DiseaseDiagnosed,
                TotalBill = this.TotalBill,
                Doctor=this.Doctor != null ? this.Doctor.MapModelToDTO() : null,
                DoctorId=this.DoctorId,
                PatientId=this.PatientId,
                Patient=this.Patient != null ? this.Patient.MapModelToDTO() : null,
                PatientDoctorScriptMedicines = this.PatientDoctorScriptMedicines.Select(psm => psm.MapModelToDTO()).ToList()
            };
        }
    }
}

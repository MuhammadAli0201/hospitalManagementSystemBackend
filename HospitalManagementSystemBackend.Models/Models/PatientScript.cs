using HospitalManagementSystemBackend.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class PatientScript
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(PatientToken))]
        public Guid PatientTokenId { get; set; }
        public PatientToken PatientToken { get; set; }
        public DateTime VisitDate { get; set; }
        public string DiseaseDiagnosed { get; set; }
        public int TotalBill { get; set; }
        public List<PatientScriptMedicine> PatientScriptMedicines { get; set; }

        public PatientScriptDTO MapModelToDTO()
        {
            return new PatientScriptDTO
            {
                Id = this.Id,
                PatientTokenId = this.PatientTokenId,
                PatientToken = this.PatientToken != null ? this.PatientToken.MapModelToDTO() : null,
                VisitDate = this.VisitDate,
                DiseaseDiagnosed = this.DiseaseDiagnosed,
                TotalBill = this.TotalBill,
                PatientScriptMedicines = this.PatientScriptMedicines.Select(psm => psm.MapModelToDTO()).ToList()
            };
        }
    }
}

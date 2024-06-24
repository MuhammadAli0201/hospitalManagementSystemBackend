using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class PatientScriptDTO
    {
        public Guid Id { get; set; }
        public Guid PatientTokenId { get; set; }
        public PatientTokenDTO PatientToken { get; set; }
        public DateTime VisitDate { get; set; }
        public string DiseaseDiagnosed { get; set; }
        public int TotalBill { get; set; }
        public List<PatientScriptMedicineDTO> PatientScriptMedicines { get; set; }

        public PatientScript MapDTOToModel()
        {
            return new PatientScript
            {
                Id = this.Id,
                PatientTokenId = this.PatientTokenId,
                PatientToken = this.PatientToken != null ? this.PatientToken.MapDTOToModel() : null,
                VisitDate = this.VisitDate,
                DiseaseDiagnosed = this.DiseaseDiagnosed,
                TotalBill = this.TotalBill,
                PatientScriptMedicines = this.PatientScriptMedicines.Select(psm => psm.MapDTOToModel()).ToList()
            };
        }
    }
}

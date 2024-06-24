using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class PatientScriptMedicineDTO
    {
        public Guid Id { get; set; }
        public Guid PatientScriptId { get; set; }
        public Guid MedicineId { get; set; }

        public PatientScriptMedicine MapDTOToModel()
        {
            return new PatientScriptMedicine
            {
                Id = this.Id,
                PatientScriptId = this.PatientScriptId,
                MedicineId = this.MedicineId,
            };
        }
    }
}

using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class DoctorDTO : PersonDTO
    {
        public string AreaOfSpecialization { get; set; }
        public List<PatientDoctorScriptDTO> PatientDoctorScripts { get; set; }
        public List<PatientDoctorTokenDTO> PatientDoctorTokens { get; set; }

        public override Doctor MapDTOToModel()
        {
            return new Doctor
            {
                Id = this.Id,
                FName = this.FName,
                LName = this.LName,
                Age = this.Age,
                DateOfBirth = this.DateOfBirth,
                MobileNo = this.MobileNo,
                CNIC = this.CNIC,
                Address = this.Address,
                AreaOfSpecialization = this.AreaOfSpecialization,
                GenderId = this.GenderId,
                Gender = this.Gender != null ? this.Gender.MapDTOToModel() : null,
            };
        }

    }
}

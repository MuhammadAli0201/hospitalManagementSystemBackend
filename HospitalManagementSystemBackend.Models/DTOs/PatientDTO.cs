using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class PatientDTO : PersonDTO
    {
        public override Patient MapDTOToModel()
        {
            return new Patient
            {
                Id = this.Id,
                FName = this.FName,
                LName = this.LName,
                Age = this.Age,
                DateOfBirth = this.DateOfBirth,
                MobileNo = this.MobileNo,
                CNIC = this.CNIC,
                Address = this.Address,
                GenderId = this.GenderId,
                Gender = this.Gender != null ? this.Gender.MapDTOToModel() : null,
            };
        }
    }
}

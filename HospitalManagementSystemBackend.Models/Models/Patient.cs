using HospitalManagementSystemBackend.Models.DTOs;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class Patient : Person
    {
        public List<PatientToken> PatientTokens { get; set; }

        public override PatientDTO MapModelToDTO()
        {
            return new PatientDTO
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
                Gender = this.Gender != null? this.Gender.MapModelToDTO() : null,
            };
        }
    }
}

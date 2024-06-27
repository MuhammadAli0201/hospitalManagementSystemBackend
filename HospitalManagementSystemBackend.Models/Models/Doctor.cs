using HospitalManagementSystemBackend.Models.DTOs;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class Doctor : Person
    {
        public string AreaOfSpecialization { get; set; }
        public List<PatientDoctorToken> PatientDoctorTokens { get; set; }
        public List<PatientDoctorScript> PatientDoctorScripts { get; set; }

        public override DoctorDTO MapModelToDTO()
        {
            return new DoctorDTO
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
                Gender = this.Gender != null? this.Gender.MapModelToDTO() : null
            };
        }
    }
}

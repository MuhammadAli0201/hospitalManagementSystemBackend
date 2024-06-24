using HospitalManagementSystemBackend.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }

        [ForeignKey(nameof(Gender))]
        public Guid GenderId { get; set; }
        public Gender Gender { get; set; }

        public virtual PersonDTO MapModelToDTO()
        {
            return new PersonDTO
            {
                Id = this.Id,
                FName = this.FName,
                LName = this.LName,
                Age = this.Age,
                DateOfBirth = this.DateOfBirth,
                MobileNo = this.MobileNo,
                CNIC = this.CNIC,
                Address = this.Address,
                GenderId=this.GenderId,
                Gender = this.Gender != null ? this.Gender.MapModelToDTO() : null
            };
        }
    }
}

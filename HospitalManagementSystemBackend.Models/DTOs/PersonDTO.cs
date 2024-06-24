using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public Guid GenderId { get; set; }
        public GenderDTO Gender { get; set; }

        public virtual Person MapDTOToModel()
        {
            return new Person { 
            Id=this.Id,
            FName=this.FName,
            LName=this.LName,
            Age=this.Age,
            DateOfBirth=this.DateOfBirth,
            MobileNo=this.MobileNo,
            CNIC=this.CNIC,
            GenderId=this.GenderId,
            Address=this.Address,
            Gender= this.Gender != null ? this.Gender.MapDTOToModel() : null
            };
        }
    }
}

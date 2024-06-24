using HospitalManagementSystemBackend.Models.DTOs;

namespace HospitalManagementSystemBackend.Models.Models
{
    public class Gender
    {
        public Guid Id { get; set; }
        public string GenderName { get; set; }
        public List<Person> Persons { get; set; }

        public GenderDTO MapModelToDTO()
        {
            return new GenderDTO
            {
                Id = this.Id,
                GenderName = this.GenderName
            };
        }
    }
}

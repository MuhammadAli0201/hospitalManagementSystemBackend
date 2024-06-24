using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class GenderDTO
    {
        public Guid Id { get; set; }
        public string GenderName { get; set; }        

        public Gender MapDTOToModel()
        {
            return new Gender
            {
                Id = this.Id,
                GenderName = this.GenderName
            };
        }
    }
}

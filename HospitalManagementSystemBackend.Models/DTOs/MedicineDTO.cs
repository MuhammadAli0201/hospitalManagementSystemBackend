using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.Models.DTOs
{
    public class MedicineDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Medicine MapDTOToModel()
        {
            return new Medicine
            {
                Id = this.Id,
                Name = this.Name,
            };
        }
    }
}

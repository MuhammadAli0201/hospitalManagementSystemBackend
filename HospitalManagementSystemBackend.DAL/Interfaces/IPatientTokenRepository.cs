using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.DAL.Interfaces
{
    public interface IPatientTokenRepository :IRepository<PatientToken>
    {
        public Task<List<PatientToken>> Search(string query);
        public Task<List<PatientToken>> SearchByDateRange(DateTime min, DateTime max);
    }
}

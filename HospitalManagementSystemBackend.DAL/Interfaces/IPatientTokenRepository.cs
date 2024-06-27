using HospitalManagementSystemBackend.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemBackend.DAL.Interfaces
{
    public interface IPatientTokenRepository :IRepository<PatientDoctorToken>
    {
        public Task<List<PatientDoctorToken>> GetLatest();
        public Task<List<PatientDoctorToken>> SearchLatest(string query);
        public Task<List<PatientDoctorToken>> SearchLatestByDateRange(DateTime min, DateTime max);
    }
}

using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HMSDbContext hMSDbContext) : base(hMSDbContext)
        {
        }
    }
}

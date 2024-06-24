using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class PatientScriptRepository : Repository<PatientScript>, IPatientScriptRepository
    {
        private readonly HMSDbContext _context;

        public PatientScriptRepository(HMSDbContext hMSDbContext) : base(hMSDbContext)
        {
            _context = hMSDbContext;
        }
    }
}

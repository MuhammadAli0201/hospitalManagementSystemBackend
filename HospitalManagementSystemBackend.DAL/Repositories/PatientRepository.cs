using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly HMSDbContext _context;

        public PatientRepository(HMSDbContext hMSDbContext) : base(hMSDbContext)
        {
            _context = hMSDbContext;
        }

        public async override Task<List<Patient>> Get()
        {
            try
            {
                var result = await _context.Patient.Include(p => p.PatientDoctorTokens).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }       
    }
}

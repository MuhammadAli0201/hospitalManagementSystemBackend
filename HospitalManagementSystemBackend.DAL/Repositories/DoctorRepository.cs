using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly HMSDbContext _context;

        public DoctorRepository(HMSDbContext hMSDbContext) : base(hMSDbContext)
        {
            _context = hMSDbContext;
        }

        public override async Task<List<Doctor>> Get()
        {
            try
            {
                var result = await _context.Doctor.Include(d => d.Gender).ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}

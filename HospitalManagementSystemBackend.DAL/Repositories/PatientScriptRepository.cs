using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class PatientScriptRepository : Repository<PatientScript>, IPatientScriptRepository
    {
        private readonly HMSDbContext _context;

        public PatientScriptRepository(HMSDbContext hMSDbContext) : base(hMSDbContext)
        {
            _context = hMSDbContext;
        }

        public async Task<List<PatientScript>> GetScriptsByTokenId(Guid tokenId)
        {
            try
            {
                var result = await _context.PatientScript.Include(ps => ps.PatientScriptMedicines).ThenInclude(psm => psm.Medicine).Where(ps => ps.PatientTokenId.Equals(tokenId)).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async override Task<PatientScript> GetSingle(Guid id)
        {
            try
            {
                var result = await _context.PatientScript.Include(ps => ps.PatientScriptMedicines).ThenInclude(psm => psm.Medicine).Where(ps => ps.Id.Equals(id)).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

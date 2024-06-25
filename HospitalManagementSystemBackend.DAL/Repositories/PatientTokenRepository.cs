using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class PatientTokenRepository : Repository<PatientToken>, IPatientTokenRepository
    {
        private readonly HMSDbContext _context;

        public PatientTokenRepository(HMSDbContext hMSDbContext) : base(hMSDbContext)
        {
            _context = hMSDbContext;
        }

        public override async Task<List<PatientToken>> Get()
        {
            try
            {
                var result = await _context.PatientToken.Include(pt => pt.Patient)
                    .ThenInclude(p => p.Gender).Include(pt => pt.Doctor).ThenInclude(d => d.Gender).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public override async Task<PatientToken> GetSingle(Guid id)
        {
            try
            {
                var result = await _context.PatientToken.Include(pt => pt.Patient)
                    .ThenInclude(p => p.Gender).Include(pt => pt.Doctor).ThenInclude(d => d.Gender).Where(pt => pt.Id.Equals(id)).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public async Task<List<PatientToken>> Search(string query)
        {
            try
            {
                if (!String.IsNullOrEmpty(query))
                {
                    var result = await (from pt in _context.PatientToken
                                        join
                                        p in _context.Patient.Include(pa => pa.Gender) on pt.PatientId equals p.Id
                                        join
                                        d in _context.Doctor.Include(dc => dc.Gender) on pt.DoctorId equals d.Id
                                        where
                                       (p.FName + " " + p.LName).Contains(query) ||
                                       p.CNIC.Contains(query) || p.MobileNo.Contains(query) ||
                                       p.Age.ToString().Contains(query) || p.Address.Contains(query)

                                        select new PatientToken
                                        {
                                            Id = p.Id,
                                            DoctorId = pt.DoctorId,
                                            Doctor = d,
                                            PatientId = pt.PatientId,
                                            Patient = p,
                                            Expiry = pt.Expiry,
                                            Status = pt.Status
                                        }
                              ).ToListAsync();
                    return result;
                }
                else
                    return await Get();
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public async Task<List<PatientToken>> SearchByDateRange(DateTime min, DateTime max)
        {
            try
            {
                if (min != DateTime.MinValue && max != DateTime.MinValue)
                {
                    var result = await (from pt in _context.PatientToken
                                        join
                                         p in _context.Patient.Include(pa => pa.Gender) on pt.PatientId equals p.Id
                                        join
                                        d in _context.Doctor.Include(dc => dc.Gender) on pt.DoctorId equals d.Id
                                        where
                                        pt.Expiry >= min && pt.Expiry <= max
                                        select new PatientToken
                                        {
                                            Id = p.Id,
                                            DoctorId = pt.DoctorId,
                                            Doctor = d,
                                            PatientId = pt.PatientId,
                                            Patient = p,
                                            Expiry = pt.Expiry,
                                            Status = pt.Status
                                        }
                              ).ToListAsync();
                    return result;
                }
                else
                    return await Get();
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }
    }
}

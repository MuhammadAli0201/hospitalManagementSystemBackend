using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class PatientTokenRepository : Repository<PatientDoctorToken>, IPatientTokenRepository
    {
        private readonly HMSDbContext _context;

        public PatientTokenRepository(HMSDbContext hMSDbContext) : base(hMSDbContext)
        {
            _context = hMSDbContext;
        }

        public override async Task<List<PatientDoctorToken>> Get()
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

        public async Task<List<PatientDoctorToken>> GetLatest()
        {
            try
            {
                var result = await _context.PatientToken.Include(pt => pt.Patient)
                    .ThenInclude(p => p.Gender).Include(pt => pt.Doctor).ThenInclude(d => d.Gender)
                    .GroupBy(pt => pt.PatientId).Select(pt => pt.OrderByDescending(p => p.UpdatedTimeStamp).FirstOrDefault()).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public override async Task<PatientDoctorToken> GetSingle(Guid id)
        {
            try
            {
                var result = await _context.PatientToken.Include(pt => pt.Patient)
                    .ThenInclude(p => p.Gender).Include(pt => pt.Doctor).ThenInclude(d => d.Gender).Where(pt => pt.Id.Equals(id))
                    .OrderByDescending(pt => pt.UpdatedTimeStamp).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message, innerException: ex.InnerException);
            }
        }

        public async Task<List<PatientDoctorToken>> SearchLatest(string query)
        {
            try
            {
                if (!String.IsNullOrEmpty(query))
                {
                    var result = (from pt in _context.PatientToken
                                  join
                                  p in _context.Patient.Include(pa => pa.Gender) on pt.PatientId equals p.Id
                                  join
                                  d in _context.Doctor.Include(dc => dc.Gender) on pt.DoctorId equals d.Id
                                  where
                                 (p.FName + " " + p.LName).Contains(query) ||
                                 p.CNIC.Contains(query) || p.MobileNo.Contains(query) ||
                                 p.Age.ToString().Contains(query) || p.Address.Contains(query)

                                  select new PatientDoctorToken
                                  {
                                      Id = p.Id,
                                      DoctorId = pt.DoctorId,
                                      Doctor = d,
                                      PatientId = pt.PatientId,
                                      Patient = p,
                                      Expiry = pt.Expiry
                                  }
                              )
                              .AsEnumerable()
                    .GroupBy(pt => pt.PatientId)
                    .Select(g => g.OrderByDescending(pt => pt.UpdatedTimeStamp).FirstOrDefault())
                    .OrderByDescending(pt => pt.UpdatedTimeStamp)
                              .ToList();
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

        public async Task<List<PatientDoctorToken>> SearchLatestByDateRange(DateTime min, DateTime max)
        {
            try
            {
                if (min != DateTime.MinValue && max != DateTime.MinValue)
                {
                    var result = (from pt in _context.PatientToken
                                  join
                                   p in _context.Patient.Include(pa => pa.Gender) on pt.PatientId equals p.Id
                                  join
                                  d in _context.Doctor.Include(dc => dc.Gender) on pt.DoctorId equals d.Id
                                  where
                                  pt.Expiry >= min && pt.Expiry <= max
                                  select new PatientDoctorToken
                                  {
                                      Id = p.Id,
                                      DoctorId = pt.DoctorId,
                                      Doctor = d,
                                      PatientId = pt.PatientId,
                                      Patient = p,
                                      Expiry = pt.Expiry
                                  }
                              ).AsEnumerable()
                    .GroupBy(pt => pt.PatientId)
                    .Select(g => g.OrderByDescending(pt => pt.UpdatedTimeStamp).FirstOrDefault())
                    .ToList();
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

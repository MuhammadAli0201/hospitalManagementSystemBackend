using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                                        p in _context.Patient on pt.PatientId equals p.Id
                                        join
                                        d in _context.Doctor on pt.DoctorId equals d.Id
                                        join
                                        pg in _context.Gender on p.GenderId equals pg.Id
                                        join
                                        dg in _context.Gender on d.GenderId equals dg.Id
                                        where
                                       (p.FName + " " + p.LName).Contains(query) ||
                                       p.CNIC.Contains(query) || p.MobileNo.Contains(query) ||
                                       p.Age.ToString().Contains(query) || p.Address.Contains(query)

                                        select new PatientToken
                                        {
                                            Id = p.Id,
                                            DoctorId = pt.DoctorId,
                                            Doctor = pt.Doctor,
                                            PatientId = pt.PatientId,
                                            Patient = pt.Patient,
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
                                        p in _context.Patient on pt.PatientId equals p.Id
                                        join
                                        d in _context.Doctor on pt.DoctorId equals d.Id
                                        join
                                        pg in _context.Gender on p.GenderId equals pg.Id
                                        join
                                        dg in _context.Gender on d.GenderId equals dg.Id
                                        where
                                        pt.Expiry >= min && pt.Expiry <= max
                                        select new PatientToken
                                        {
                                            Id = p.Id,
                                            DoctorId = pt.DoctorId,
                                            Doctor = pt.Doctor,
                                            PatientId = pt.PatientId,
                                            Patient = pt.Patient,
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

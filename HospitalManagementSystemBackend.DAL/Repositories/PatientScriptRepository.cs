﻿using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystemBackend.DAL.Repositories
{
    public class PatientScriptRepository : Repository<PatientDoctorScript>, IPatientScriptRepository
    {
        private readonly HMSDbContext _context;

        public PatientScriptRepository(HMSDbContext hMSDbContext) : base(hMSDbContext)
        {
            _context = hMSDbContext;
        }

        public async Task<List<PatientDoctorScript>> GetScriptsByPatientId(Guid patientId)
        {
            try
            {
                var result = await _context.PatientScript
                    .Include(ps => ps.PatientDoctorToken).Include(pt => pt.Doctor).Include(pt=>pt.Patient)
                    .Include(ps => ps.PatientDoctorScriptMedicines).ThenInclude(psm => psm.Medicine)
                    .Where(ps => ps.PatientId.Equals(patientId)).OrderByDescending(ps => ps.VisitDate).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async override Task<PatientDoctorScript> GetSingle(Guid id)
        {
            try
            {
                var result = await _context.PatientScript.Include(ps => ps.PatientDoctorScriptMedicines).ThenInclude(psm => psm.Medicine).Where(ps => ps.Id.Equals(id)).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

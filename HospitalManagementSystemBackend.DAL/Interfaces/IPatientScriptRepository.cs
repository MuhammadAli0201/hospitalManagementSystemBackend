using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.DAL.Interfaces
{
    public interface IPatientScriptRepository : IRepository<PatientDoctorScript>
    {
        public Task<List<PatientDoctorScript>> GetScriptsByPatientId(Guid patientId);
    }
}

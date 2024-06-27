using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.DAL.Interfaces
{
    public interface IPatientScriptRepository : IRepository<PatientDoctorScript>
    {
        public Task<List<PatientDoctorScript>> GetScriptsByTokenId(Guid tokenId);
    }
}

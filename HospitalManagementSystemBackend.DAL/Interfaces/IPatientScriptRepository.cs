using HospitalManagementSystemBackend.Models.Models;

namespace HospitalManagementSystemBackend.DAL.Interfaces
{
    public interface IPatientScriptRepository : IRepository<PatientScript>
    {
        public Task<List<PatientScript>> GetScriptsByTokenId(Guid tokenId);
    }
}

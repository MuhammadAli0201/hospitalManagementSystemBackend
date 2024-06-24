using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientScriptController : ControllerBase
    {
        private readonly IPatientScriptRepository _patientScriptRepository;

        public PatientScriptController(IPatientScriptRepository patientScriptRepository)
        {
            _patientScriptRepository = patientScriptRepository;
        }

        [HttpPost(nameof(CreateOrUpdate))]
        public async Task<IActionResult> CreateOrUpdate(PatientScriptDTO patientScriptDTO)
        {
            var patientScript = patientScriptDTO.MapDTOToModel();
            if (patientScript.Id == Guid.Empty)
                patientScript = await _patientScriptRepository.Add(patientScript);
            else
                patientScript = await _patientScriptRepository.Update(patientScript);

            if (patientScript == null) return BadRequest();

            patientScriptDTO=patientScript.MapModelToDTO();
            return Ok(patientScriptDTO);
        }
    }
}

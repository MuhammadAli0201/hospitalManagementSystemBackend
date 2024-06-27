using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDoctorScriptController : ControllerBase
    {
        private readonly IPatientScriptRepository _patientScriptRepository;

        public PatientDoctorScriptController(IPatientScriptRepository patientScriptRepository)
        {
            _patientScriptRepository = patientScriptRepository;
        }

        [HttpPost(nameof(CreateOrUpdate))]
        public async Task<IActionResult> CreateOrUpdate(PatientDoctorScriptDTO patientScriptDTO)
        {
            var patientScript = patientScriptDTO.MapDTOToModel();
            if (patientScript.Id == Guid.Empty)
                patientScript = await _patientScriptRepository.Add(patientScript);
            else
                patientScript = await _patientScriptRepository.Update(patientScript);

            if (patientScript == null) return BadRequest();

            patientScriptDTO = patientScript.MapModelToDTO();
            return Ok(patientScriptDTO);
        }

        [HttpGet(nameof(GetById))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _patientScriptRepository.GetSingle(id);
            if (response == null) return NotFound();

            var patientScriptTokenDTO = response.MapModelToDTO();
            return Ok(patientScriptTokenDTO);
        }

        [HttpGet(nameof(GetScriptsByTokenId))]
        public async Task<IActionResult> GetScriptsByTokenId(Guid tokenId)
        {
            var response = await _patientScriptRepository.GetScriptsByTokenId(tokenId);
            List<PatientDoctorScriptDTO> patientTokenDTOs = response.Select(r => r.MapModelToDTO()).ToList();
            return Ok(patientTokenDTOs);
        }
    }
}

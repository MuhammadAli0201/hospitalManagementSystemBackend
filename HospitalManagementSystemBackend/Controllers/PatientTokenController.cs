using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.DTOs;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTokenController : ControllerBase
    {
        private readonly IPatientTokenRepository _patientTokenRepository;

        public PatientTokenController(IPatientTokenRepository patientTokenRepository)
        {
            _patientTokenRepository = patientTokenRepository;
        }

        [HttpPost(nameof(CreateOrUpdate))]
        public async Task<IActionResult> CreateOrUpdate(PatientTokenDTO token)
        {
            var patientToken = token.MapDTOToModel();
            if (token.Id == Guid.Empty)
                patientToken = await _patientTokenRepository.Add(patientToken);
            else
                patientToken = await _patientTokenRepository.Update(patientToken);

            if (patientToken == null) return BadRequest();

            token = patientToken.MapModelToDTO();
            return Ok(token);
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var response = await _patientTokenRepository.Get();
            List<PatientTokenDTO> patientTokens = response.Select(r => r.MapModelToDTO()).ToList();
            return Ok(patientTokens);
        }

        [HttpGet(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var response = await _patientTokenRepository.GetSingle(id);
            if (response == null) return NotFound();

            return Ok(response.MapModelToDTO());
        }
        
        [HttpGet(nameof(Search))]
        public async Task<IActionResult> Search(string query)
        {
            var response = await _patientTokenRepository.Search(query);
            List<PatientTokenDTO> patientTokenDTOs = response.Select(r => r.MapModelToDTO()).ToList();
            return Ok(patientTokenDTOs);
        }

        [HttpGet(nameof(SearchByDateRange))]
        public async Task<IActionResult> SearchByDateRange(DateTime min, DateTime max)
        {
            var response = await _patientTokenRepository.SearchByDateRange(min,max);
            List<PatientTokenDTO> patientTokenDTOs = response.Select(r => r.MapModelToDTO()).ToList();
            return Ok(patientTokenDTOs);
        }
    }
}

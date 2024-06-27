using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.DTOs;
using HospitalManagementSystemBackend.Models.Enums;
using HospitalManagementSystemBackend.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDoctorTokenController : ControllerBase
    {
        private readonly IPatientTokenRepository _patientTokenRepository;
        private readonly IPatientScriptRepository _patientScriptRepository;
        private readonly IPatientRepository _patientRepository;

        public PatientDoctorTokenController(IPatientTokenRepository patientTokenRepository,
            IPatientScriptRepository patientScriptRepository, IPatientRepository patientRepository)
        {
            _patientTokenRepository = patientTokenRepository;
            _patientScriptRepository = patientScriptRepository;
            _patientRepository = patientRepository;
        }

        [HttpPost(nameof(CreateOrUpdate))]
        public async Task<IActionResult> CreateOrUpdate(PatientDoctorTokenDTO token)
        {
            var patientToken = token.MapDTOToModel();
            var newExpiry = DateTime.Now.AddDays(3);
            patientToken.UpdatedTimeStamp = DateTime.Now;

            if (token.Id == Guid.Empty)
            {
                patientToken.Expiry = newExpiry;
                patientToken = await _patientTokenRepository.Add(patientToken);
            }
            else
            {
                if (token.Status.Equals(PatientTokenExpiry.Expired))
                {
                    //Updating Patient
                    var patientResponse = await _patientRepository.Update(patientToken.Patient);
                    if (patientResponse == null) return BadRequest("Oops. Unable to update patient.");

                    //Adding New Patient Token Row if Status is expired.
                    patientToken.Id = Guid.NewGuid();
                    patientToken.Expiry = newExpiry;
                    patientToken.PatientId = patientResponse.Id;
                    patientToken.Patient = null;
                    patientToken = await _patientTokenRepository.Add(patientToken);
                    if (patientToken != null) patientToken.Patient = patientResponse;
                }
                else
                    patientToken = await _patientTokenRepository.Update(patientToken); //updating if Status is Active.
            }

            if (patientToken == null) return BadRequest("Oops. Unable to update patient token.");

            token = patientToken.MapModelToDTO();
            return Ok(token);
        }

        [HttpGet(nameof(GetLatestAll))]
        public async Task<IActionResult> GetLatestAll()
        {
            var response = await _patientTokenRepository.GetLatest();
            List<PatientDoctorTokenDTO> patientTokens = response.Select(r => r.MapModelToDTO()).ToList();
            return Ok(patientTokens);
        }

        [HttpGet(nameof(IsTokenUpdateable))]
        public async Task<IActionResult> IsTokenUpdateable(Guid id)
        {
            var response = await _patientScriptRepository.GetScriptsByTokenId(id);
            if (response.Any()) return Ok(false);
            else return Ok(true);
        }

        [HttpGet(nameof(GetSingle))]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            var response = await _patientTokenRepository.GetSingle(id);
            if (response == null) return NotFound();

            return Ok(response.MapModelToDTO());
        }

        [HttpGet(nameof(SearchLatest))]
        public async Task<IActionResult> SearchLatest(string query)
        {
            var response = await _patientTokenRepository.SearchLatest(query);
            List<PatientDoctorTokenDTO> patientTokenDTOs = response.Select(r => r.MapModelToDTO()).ToList();
            return Ok(patientTokenDTOs);
        }

        [HttpGet(nameof(SearchLatestByDateRange))]
        public async Task<IActionResult> SearchLatestByDateRange(DateTime min, DateTime max)
        {
            var response = await _patientTokenRepository.SearchLatestByDateRange(min, max);
            List<PatientDoctorTokenDTO> patientTokenDTOs = response.Select(r => r.MapModelToDTO()).ToList();
            return Ok(patientTokenDTOs);
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _patientTokenRepository.GetSingle(id);
            if (result == null) return NotFound();

            var response = await _patientTokenRepository.Delete(id);
            var patientTokenDTO = response.MapModelToDTO();
            return Ok(patientTokenDTO);
        }
    }
}

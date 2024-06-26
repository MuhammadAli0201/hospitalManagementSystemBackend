﻿using HospitalManagementSystemBackend.DAL.Interfaces;
using HospitalManagementSystemBackend.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTokenController : ControllerBase
    {
        private readonly IPatientTokenRepository _patientTokenRepository;
        private readonly IPatientScriptRepository _patientScriptRepository;

        public PatientTokenController(IPatientTokenRepository patientTokenRepository,
            IPatientScriptRepository patientScriptRepository)
        {
            _patientTokenRepository = patientTokenRepository;
            _patientScriptRepository = patientScriptRepository;
        }

        [HttpPost(nameof(CreateOrUpdate))]
        public async Task<IActionResult> CreateOrUpdate(PatientTokenDTO token)
        {
            var patientToken = token.MapDTOToModel();
            patientToken.Token = Guid.NewGuid();

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

        [HttpGet(nameof(IsTokenUpdateable))]
        public async Task<IActionResult> IsTokenUpdateable(Guid id)
        {
            var response = await _patientScriptRepository.GetScriptsByTokenId(id);
            if(response.Any()) return Ok(false);
            else return Ok(true);
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
            var response = await _patientTokenRepository.SearchByDateRange(min, max);
            List<PatientTokenDTO> patientTokenDTOs = response.Select(r => r.MapModelToDTO()).ToList();
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

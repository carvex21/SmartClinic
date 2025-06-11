using Microsoft.AspNetCore.Mvc;
using SmartClinic.Application.DTOs;
using SmartClinic.Application.Mappings;
using SmartClinic.Application.Services;

namespace SmartClinic.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientsService _patientsService;
    private readonly ILogger<PatientsController> _logger;

    public PatientsController(ILogger<PatientsController> logger, IPatientsService patientsService)
    {
        _logger = logger;
        _patientsService = patientsService;
    }

    [HttpGet("{id}", Name = "GetPatientById")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patientDto = await _patientsService.GetPatient(id);
        _logger.LogInformation("Patient Retrieved: {PatientName} {PatientLastName", patientDto.FirstName, patientDto.LastName);
        return Ok(patientDto);
    }

    [HttpPost(Name = "CreatePatient")]
    public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
    {
        var result = await _patientsService.CreatePatient(patientDto);
        _logger.LogInformation("Patient Created! Patient name: {patientName}", patientDto.FirstName);
        return Ok(result);
    }

    [HttpDelete("{id}", Name = "DeletePatient")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        _logger.LogInformation("Patient Deleted!");
        return Ok(await _patientsService.DeletePatient(id));
    }

    [HttpPut("{id}", Name = "UpdatePatient")]
    public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
    {
        var result = await _patientsService.UpdatePatientAsync(id, patientDto);
        _logger.LogInformation("Patient Updated: {patientDto} {patientDto}", patientDto.FirstName, patientDto.LastName);
        return Ok(result);
    }
}
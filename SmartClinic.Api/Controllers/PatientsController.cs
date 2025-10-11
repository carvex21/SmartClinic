using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.DTOs;
using SmartClinic.Core.Services;
using FluentValidation;
using SmartClinic.Core.Validators;

namespace SmartClinic.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientsService _patientsService;
    private readonly ILogger<PatientsController> _logger;
    private readonly PatientDtoValidator _validator;

    public PatientsController(
        ILogger<PatientsController> logger, 
        IPatientsService patientsService,
        PatientDtoValidator validator)
    {
        _logger = logger;
        _patientsService = patientsService;
        _validator = validator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patientDto = await _patientsService.GetPatient(id);

        if (patientDto == null)
        {
            _logger.LogInformation("There is no patient with the given ID in the database!");
            return NotFound("Patient not found.");
        }

        _logger.LogInformation("Patient Retrieved: {PatientName} {PatientLastName}", patientDto.FirstName, patientDto.LastName);
        return Ok(patientDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var patientListDto = await _patientsService.GetAllPatients();

        if (!patientListDto.Any())
        {
            return NotFound("No patients found.");
        }

        foreach (var patientDto in patientListDto)
        {
            _logger.LogInformation("Patients Retrieved: {PatientName} {PatientLastName}", patientDto.FirstName, patientDto.LastName);

        }
        return Ok(patientListDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
    {
        var validationResult = await _validator.ValidateAsync(patientDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var result = await _patientsService.CreatePatient(patientDto);
        _logger.LogInformation("Patient Created! Patient name: {patientName}", patientDto.FirstName);
        return CreatedAtAction(nameof(GetPatient), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var result = await _patientsService.DeletePatient(id);
        if (result == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Patient Deleted!");
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
    {
        var validationResult = await _validator.ValidateAsync(patientDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var result = await _patientsService.UpdatePatientAsync(id, patientDto);
        if (result == null)
        {
            return NotFound();
        }
        _logger.LogInformation("Patient Updated: {PatientName} {PatientLastName}", patientDto.FirstName, patientDto.LastName);
        return Ok(result);
    }
}
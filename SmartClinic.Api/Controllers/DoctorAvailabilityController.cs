using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.DTOs;
using SmartClinic.Core.Models;
using SmartClinic.Core.Services;

namespace SmartClinic.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorAvailabilityController : ControllerBase
{
    private readonly IDoctorsService _doctorsService;
    private readonly IDoctorAvailabilityService _doctorAvailabilityService;
    private readonly ILogger<BranchesController> _logger;

    public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService, ILogger<BranchesController> logger, IDoctorsService doctorsService)
    {
        _doctorAvailabilityService = doctorAvailabilityService;
        _logger = logger;
        _doctorsService = doctorsService;
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetDoctorAvailability(int doctorId, [FromQuery] DateTime date)
    {
        var availability = await _doctorAvailabilityService.GetDoctorAvailability(doctorId, date);
        
        var doctor = await _doctorsService.GetDoctor(doctorId);

        if (doctor == null)
        {
            _logger.LogInformation("Doctor with ID {DoctorId} not found", doctorId);
            return NotFound("There is no doctor with the provided ID.");
        }

        if (!availability.Any())
        {
            _logger.LogInformation("Doctor {Doctor} has no available slots on {Date}", doctor.LastName, date.ToShortDateString());
            return NotFound("No available slots found.");
        }

        _logger.LogInformation("Doctor {Doctor} has {Count} available slots on {Date}", doctor.LastName, availability.Count, date.ToShortDateString());
        return Ok(availability);
    }
}
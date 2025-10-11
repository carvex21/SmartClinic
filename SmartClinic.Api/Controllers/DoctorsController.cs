using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.DTOs;
using SmartClinic.Core.Services;

namespace SmartClinic.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorsService _doctorsService;
    private readonly ILogger<DoctorsController> _logger;

    public DoctorsController(ILogger<DoctorsController> logger, IDoctorsService doctorsService)
    {
        _logger = logger;
        _doctorsService = doctorsService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctor(int id)
    {
        var doctorDto = await _doctorsService.GetDoctor(id);

        if (doctorDto == null)
        {
            _logger.LogInformation("Doctor with ID {DoctorId} not found", id);
            return NotFound("There is no doctor with the provided ID.");
        }

        _logger.LogInformation("Doctor Retrieved: {DoctorName} {DoctorLastName}", doctorDto.FirstName, doctorDto.LastName);
        return Ok(doctorDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = await _doctorsService.GetAllDoctors();

        if (!doctors.Any())
        {
            _logger.LogInformation("No doctors found in the system.");
            return NotFound("No doctors found.");
        }

        foreach (var doctor in doctors)
        {
            _logger.LogInformation("Doctors Retrieved: {DoctorName} {DoctorLastName}", doctor.FirstName, doctor.LastName);
        }

        return Ok(doctors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] DoctorDto doctorDto)
    {
        var result = await _doctorsService.CreateDoctor(doctorDto);
        _logger.LogInformation("Doctor Created! Doctor name: {doctorName}", doctorDto.FirstName);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        _logger.LogInformation("Doctor Deleted!");
        return Ok(await _doctorsService.DeleteDoctor(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDto doctorDto)
    {
        var result = await _doctorsService.UpdateDoctorAsync(id, doctorDto);
        _logger.LogInformation("Doctor Updated: {doctorDto} {doctorDto}", doctorDto.FirstName, doctorDto.LastName);
        return Ok(result);
    }
}
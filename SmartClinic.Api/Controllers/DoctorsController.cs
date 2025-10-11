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

    [HttpGet]
    public async Task<IActionResult> GetDoctor(int id)
    {
        var doctorDto = await _doctorsService.GetDoctor(id);
        _logger.LogInformation("Doctor Retrieved: {DoctorName} {DoctorLastName}", doctorDto.FirstName, doctorDto.LastName);
        return Ok(doctorDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] DoctorDto doctorDto)
    {
        var result = await _doctorsService.CreateDoctor(doctorDto);
        _logger.LogInformation("Doctor Created! Doctor name: {doctorName}", doctorDto.FirstName);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        _logger.LogInformation("Doctor Deleted!");
        return Ok(await _doctorsService.DeleteDoctor(id));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDto doctorDto)
    {
        var result = await _doctorsService.UpdateDoctorAsync(id, doctorDto);
        _logger.LogInformation("Doctor Updated: {doctorDto} {doctorDto}", doctorDto.FirstName, doctorDto.LastName);
        return Ok(result);
    }
}
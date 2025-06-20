using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.DTOs;
using SmartClinic.Core.Services;

namespace SmartClinic.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentsService _appointmentsService;
    private readonly ILogger<AppointmentsController> _logger;

    public AppointmentsController(ILogger<AppointmentsController> logger, IAppointmentsService appointmentsService)
    {
        _logger = logger;
        _appointmentsService = appointmentsService;
    }

    [HttpPost("CreateAppointment")]
    public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDto appointmentDto)
    {
        var result = await _appointmentsService.CreateAppointment(appointmentDto);
        _logger.LogInformation("Appointment created");
        return Ok(result);
    }
}
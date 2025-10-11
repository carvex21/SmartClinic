using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.Services;

namespace SmartClinic.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicalRecordController : ControllerBase
{
    private readonly IMedicalRecordService _medicalRecordService;
    private readonly ILogger<MedicalRecordController> _logger;

    public MedicalRecordController(ILogger<MedicalRecordController> logger, IMedicalRecordService medicalRecordService)
    {
        _medicalRecordService = medicalRecordService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMedicalRecord(int patientId)
    {
        var result = await _medicalRecordService.GetRecord();
        _logger.LogInformation("GetMedicalRecordByPatientId: {patientId}", patientId);
        return Ok(result);
    }
}
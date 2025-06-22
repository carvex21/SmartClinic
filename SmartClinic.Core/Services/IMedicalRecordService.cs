using SmartClinic.Core.Models;

namespace SmartClinic.Core.Services;

public interface IMedicalRecordService
{
    Task<MedicalRecord?> GetRecord();
}
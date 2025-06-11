using SmartClinic.Application.DTOs;

namespace SmartClinic.Application.Services;

public interface IPatientsService
{
    Task<PatientDto?> GetPatient(int id);
    Task<PatientDto> CreatePatient(PatientDto patientDto);
    Task<PatientDto?> DeletePatient(int id);
    Task<PatientDto?> UpdatePatientAsync(int id, PatientDto patientDto);
}
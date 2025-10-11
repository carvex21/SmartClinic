using SmartClinic.Core.DTOs;

namespace SmartClinic.Core.Services;

public interface IPatientsService
{
    Task<PatientDto?> GetPatient(int id);
    Task<PatientDto> CreatePatient(PatientDto patientDto);
    Task<PatientDto?> DeletePatient(int id);
    Task<PatientDto?> UpdatePatientAsync(int id, PatientDto patientDto);
    Task<List<PatientDto>> GetAllPatients();
}
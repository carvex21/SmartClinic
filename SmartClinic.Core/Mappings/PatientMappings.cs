using SmartClinic.Application.DTOs;
using SmartClinic.Infrastructure.Models;

namespace SmartClinic.Application.Mappings;

public static class PatientMappings
{
    public static PatientDto ToDto(this Patient patient)
    {
        return new PatientDto(patient.Id, patient.FirstName, patient.LastName, patient.Email);
    }

    public static Patient ToDomain(this PatientDto patientDto)
    {
        return new Patient(patientDto.Id, patientDto.FirstName, patientDto.LastName, patientDto.Email);
    }
}
using SmartClinic.Core.DTOs;
using SmartClinic.Core.Models;

namespace SmartClinic.Core.Extensions;

public static class DoctorMappings
{
    public static DoctorDto ToDto(this Doctor doctor)
    {
        return new DoctorDto(doctor.Id, doctor.FirstName, doctor.LastName, doctor.Specialty, doctor.BranchId);
    }

    public static Doctor ToDomain(this DoctorDto doctorDto)
    {
        return new Doctor(doctorDto.Id, doctorDto.FirstName, doctorDto.LastName, doctorDto.Specialty, doctorDto.BranchId);
    }
}
using SmartClinic.Core.DTOs;

namespace SmartClinic.Core.Services;

public interface IDoctorsService
{
    Task<DoctorDto?> GetDoctor(int id);
    Task<DoctorDto?> CreateDoctor(DoctorDto doctorDto);
    Task<DoctorDto?> DeleteDoctor(int id);
    Task<DoctorDto?> UpdateDoctorAsync(int id, DoctorDto doctorDto);
}
using SmartClinic.Core.Models;

namespace SmartClinic.Core.Services;

public interface IDoctorAvailabilityService
{
    Task<List<Appointment>> GetDoctorAvailability(int doctorId, DateTime date);
}
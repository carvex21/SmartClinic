using SmartClinic.Core.DTOs;

namespace SmartClinic.Core.Services;

public interface IAppointmentsService
{
    Task<AppointmentDto?> CreateAppointment(AppointmentDto appointmentDto);
}
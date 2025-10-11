using SmartClinic.Core.DTOs;
using SmartClinic.Core.Models;

namespace SmartClinic.Core.Extensions;

public static class AppointmentMappings
{
    public static Appointment ToDomain(this AppointmentDto appointmentDto)
    {
        return new Appointment(appointmentDto.Id, appointmentDto.PatientId, appointmentDto.DoctorId, appointmentDto.Date);
    }

    public static AppointmentDto ToDto(this Appointment appointment)
    {
        return new AppointmentDto(appointment.Id, appointment.PatientId, appointment.DoctorId, appointment.Date);
    }
}
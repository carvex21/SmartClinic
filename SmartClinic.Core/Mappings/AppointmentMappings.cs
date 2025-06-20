using SmartClinic.Core.DTOs;
using SmartClinic.Core.Models;

namespace SmartClinic.Core.Mappings;

public static class AppointmentMappings
{
    public static Appointment ToDomain(this AppointmentDto appointmentDto)
    {
        return new Appointment(appointmentDto.Id, appointmentDto.PatientId, appointmentDto.DoctorId, appointmentDto.Status);
    }

    public static AppointmentDto ToDto(this Appointment appointment)
    {
        return new AppointmentDto(appointment.Id, appointment.PatientId, appointment.DoctorId, appointment.Status);
    }
}
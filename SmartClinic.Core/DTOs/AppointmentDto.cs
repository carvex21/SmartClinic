namespace SmartClinic.Core.DTOs;

public class AppointmentDto
{
    public AppointmentDto(int id, int patientId, int doctorId, string status)
    {
        Id = id;
        PatientId = patientId;
        DoctorId = doctorId;
        Status = status;
    }

    public int Id { get; }

    public int PatientId { get; }

    public int DoctorId { get; }

    public string Status { get; }
}
namespace SmartClinic.Core.DTOs;

public class AppointmentDto
{
    public AppointmentDto(int id, int patientId, int doctorId, DateTime date)
    {
        Id = id;
        PatientId = patientId;
        DoctorId = doctorId;
        Date = date;
    }

    public int Id { get; }

    public int PatientId { get; }

    public int DoctorId { get; }

    public DateTime Date { get; }
}
namespace SmartClinic.Core.Models;

public class Appointment
{
    public Appointment(int id, int patientId, int doctorId, string status)
    {
        Id = id;
        PatientId = patientId;
        DoctorId = doctorId;
        Status = status;
    }

    protected Appointment()
    {
    }

    public int Id { get; }

    public int PatientId { get; }

    public int DoctorId { get; }

    public string Status { get; }
}
namespace SmartClinic.Core.Models;

public class Appointment
{
    public Appointment(int id, int patientId, int doctorId, DateTime date)
    {
        Id = id;
        PatientId = patientId;
        DoctorId = doctorId;
        Date = date;
    }

    protected Appointment()
    {
    }

    public int Id { get; }

    public int PatientId { get; }

    public int DoctorId { get; }
    
    public DateTime Date { get; }
}
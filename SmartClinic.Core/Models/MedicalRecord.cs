namespace SmartClinic.Core.Models;

public class MedicalRecord
{
    public MedicalRecord(int id, int patientId, List<Appointment> appointments)
    {
        Id = id;
        PatientId = patientId;
        Appointments = appointments;
    }

    protected MedicalRecord()
    {
    }

    public int Id { get; set; }

    public int PatientId { get; set; }

    public List<Appointment> Appointments { get; set; }
}
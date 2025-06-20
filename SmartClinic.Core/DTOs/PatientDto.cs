namespace SmartClinic.Core.DTOs;

public class PatientDto
{
    public PatientDto(int id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    public int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }
}
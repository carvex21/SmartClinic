namespace SmartClinic.Core.Models;

public class Patient
{
    public Patient(int id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    protected Patient()
    {
    }

    public int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }
}
namespace SmartClinic.Core.Models;

public class Doctor
{
    public Doctor(int id, string firstName, string lastName, string specialty, string branchId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Specialty = specialty;
        BranchId = branchId;
    }

    protected Doctor()
    {
    }

    public int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Specialty { get; }

    public string BranchId { get; }
}
namespace SmartClinic.Core.DTOs;

public class DoctorDto
{
    public DoctorDto(int id, string firstName, string lastName, string specialty, string branchId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Specialty = specialty;
        BranchId = branchId;
    }

    public int Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Specialty { get; }

    public string BranchId { get; }
}
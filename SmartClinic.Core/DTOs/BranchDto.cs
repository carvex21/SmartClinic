namespace SmartClinic.Core.DTOs;

public class BranchDto
{
    public BranchDto(int id, string location)
    {
        Id = id;
        Location = location;
    }

    public int Id { get; }

    public string Location { get; }
}
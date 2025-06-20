namespace SmartClinic.Core.Models;

public class Branch
{
    public Branch(int id, string location)
    {
        Id = id;
        Location = location;
    }

    protected Branch()
    {
    }

    public int Id { get; }

    public string Location { get; }
}
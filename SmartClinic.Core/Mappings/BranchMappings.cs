using SmartClinic.Core.Models;
using SmartClinic.Core.DTOs;

namespace SmartClinic.Core.Mappings;

public static class BranchMappings
{
    public static Branch ToDomain(this BranchDto branchDto)
    {
        return new Branch(branchDto.Id, branchDto.Location);
    }

    public static BranchDto ToDto(this Branch branch)
    {
        return new BranchDto(branch.Id, branch.Location);
    }
}
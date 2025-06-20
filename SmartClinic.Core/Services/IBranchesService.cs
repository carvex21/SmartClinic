using SmartClinic.Core.DTOs;

namespace SmartClinic.Core.Services;

public interface IBranchesService
{
    Task<BranchDto?> GetBranch(int branchId);
    Task<List<BranchDto>> GetAllBranches();
    Task<BranchDto?> CreateBranch(BranchDto branchDto);
    Task<BranchDto?> UpdateBranch(BranchDto branchDto);
    Task<BranchDto?> DeleteBranch(int branchId);
}
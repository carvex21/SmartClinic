﻿using Microsoft.AspNetCore.Mvc;
using SmartClinic.Core.DTOs;
using SmartClinic.Core.Services;

namespace SmartClinic.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BranchesController : ControllerBase
{
    private readonly IBranchesService _branchesService;
    private readonly ILogger<BranchesController> _logger;

    public BranchesController(IBranchesService branchesService, ILogger<BranchesController> logger)
    {
        _branchesService = branchesService;
        _logger = logger;
    }

    [HttpGet("id", Name = "GetBranchById")]
    public async Task<IActionResult> GetBranchById(int branchId)
    {
        var branchDto = await _branchesService.GetBranch(branchId);
        _logger.LogInformation($"Branch {branchId} found, it is located in {branchDto.Location}");
        return Ok(branchDto);
    }

    [HttpGet(Name = "GetBranches")]
    public async Task<IActionResult> GetBranches()
    {
        var branches = await _branchesService.GetAllBranches();
        _logger.LogInformation("GetAllBranches completed");
        return Ok(branches);
    }

    [HttpPost(Name = "CreateBranch")]
    public async Task<IActionResult> CreateBranch([FromBody] BranchDto branchDto)
    {
        var result = await _branchesService.CreateBranch(branchDto);
        _logger.LogInformation("Branch completed");
        return Ok(result);
    }

    [HttpPut(Name = "UpdateBranch")]
    public async Task<IActionResult> UpdateBranch([FromBody] BranchDto branchDto)
    {
        var result = await _branchesService.UpdateBranch(branchDto);
        _logger.LogInformation("Branch updated");
        return Ok(result);
    }

    [HttpDelete(Name = "DeleteBranch")]
    public async Task<IActionResult> DeleteBranch(int branchId)
    {
        var result = await _branchesService.DeleteBranch(branchId);
        _logger.LogInformation("Branch deleted");
        return Ok(result);
    }
}
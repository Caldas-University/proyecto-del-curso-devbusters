namespace EventManagement.Api.Controllers;

using EventManagement.Application.Contracts.Services;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class RolePermissionController : ControllerBase
{
    private readonly IRolePermissionServiceApp _rolePermissionService;
    private readonly IRoleServiceApp _roleService;
    private readonly IPermissionServiceApp _permissionService;
    private readonly IMapper _mapper;

    public RolePermissionController(IRolePermissionServiceApp rolePermissionService, IMapper mapper, IRoleServiceApp roleService, IPermissionServiceApp permissionService)
    {
        _rolePermissionService = rolePermissionService;
        _roleService = roleService;
        _permissionService = permissionService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddRolePermission(RolePermissionRequestDTO rolePermissionDTO)
    {
        if (rolePermissionDTO == null)
        {
            return BadRequest("Role permission data is null");
        }

        var rolePermissionEntity = _mapper.Map<RolePermission>(rolePermissionDTO);
        if (rolePermissionEntity.idRole == Guid.Empty || rolePermissionEntity.idPermission == Guid.Empty)
        {
            return BadRequest("Role ID and Permission ID cannot be empty");
        }
        // Check if the role and permission exist
        var role = await _roleService.GetRoleByIdAsync(rolePermissionEntity.idRole);
        var permission = await _permissionService.GetPermissionByIdAsync(rolePermissionEntity.idPermission);

        if (role.id != rolePermissionEntity.idRole || permission.id != rolePermissionEntity.idPermission)
        {
            return BadRequest("Role or Permission does not exist");
        }

        var createdRolePermission = await _rolePermissionService.AddRolePermissionAsync(rolePermissionEntity);

        if (createdRolePermission == Guid.Empty)
        {
            return StatusCode(500, "An error occurred while creating the role permission");
        }

        var responseRolePermissionDTO = _mapper.Map<RolePermissionResponseDTO>(rolePermissionEntity);
        return Ok(responseRolePermissionDTO);



    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRolePermissionByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid role permission ID");
        }

        try
        {
            var rolePermissionEntity = await _rolePermissionService.GetRolePermissionByIdAsync(id);
            var responseRolePermissionDTO = _mapper.Map<RolePermissionResponseDTO>(rolePermissionEntity);
            return Ok(responseRolePermissionDTO);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Role permission with ID {id} not found");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving the role permission: {ex.Message}");
        }
    }
}
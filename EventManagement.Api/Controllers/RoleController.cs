namespace EventManagement.Api.Controllers;

using EventManagement.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;


[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleServiceApp _RoleService;
    private readonly IMapper _mapper;

    public RoleController(IRoleServiceApp roleService, IMapper mapper)
    {
        _mapper = mapper;
        _RoleService = roleService;
    }

    [HttpPost]
    public async Task<IActionResult> AddRole(CreateRequestRoleDTO roleDTO)
    {
        if (roleDTO == null)
        {
            return BadRequest("Role data is null");
        }

        var roleEntity = _mapper.Map<Role>(roleDTO);
        var createdRole = await _RoleService.RoleAsync(roleEntity);

        if (createdRole == Guid.Empty)
        {
            return BadRequest("Failed to create role");
        }

        var responseRoleDTO = _mapper.Map<CreateResponseRoleDTO>(roleEntity);
        return Ok(responseRoleDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid role ID");
        }

        var roleEntity = await _RoleService.GetRoleByIdAsync(id);
        if (roleEntity == null)
        {
            return NotFound($"Role with ID {id} not found");
        }

        var roleDTO = _mapper.Map<CreateResponseRoleDTO>(roleEntity);
        return Ok(roleDTO);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRolesAsync()
    {
        var roles = await _RoleService.GetAllRolesAsync();
        if (roles == null || !roles.Any())
        {
            return NotFound("No roles found");
        }

        var roleDTOs = _mapper.Map<IEnumerable<CreateResponseRoleDTO>>(roles);
        return Ok(roleDTOs);
    }
}

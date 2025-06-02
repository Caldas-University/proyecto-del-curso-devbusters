namespace EventManagement.Api.Controllers;

using EventManagement.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;


[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionServiceApp _PermissionService;
    private readonly IMapper _mapper;

    public PermissionController(IPermissionServiceApp permissionService, IMapper mapper)
    {
        _mapper = mapper;
        _PermissionService = permissionService;
    }

    [HttpPost]
    public IActionResult AddPermission(CreateRequestPermissionDTO permissionDTO)
    {
        if (permissionDTO == null)
        {
            return BadRequest("Permission data is null");
        }

        var permissionEntity = _mapper.Map<Permission>(permissionDTO);
        var createdPermission = _PermissionService.PermissionAsync(permissionEntity);

        if (createdPermission == null)
        {
            return BadRequest("Failed to create permission");
        }

        var responsePermissionDTO = _mapper.Map<CreateResponsePermissionDTO>(permissionEntity);
        return Ok(responsePermissionDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPermissionByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid permission ID");
        }

        var permissionEntity = await _PermissionService.GetPermissionByIdAsync(id);
        if (permissionEntity == null)
        {
            return NotFound($"Permission with ID {id} not found");
        }

        var permissionDTO = _mapper.Map<CreateResponsePermissionDTO>(permissionEntity);
        return Ok(permissionDTO);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPermissionsAsync()
    {
        var permissions = await _PermissionService.GetAllPermissionsAsync();
        if (permissions == null || !permissions.Any())
        {
            return NotFound("No permissions found");
        }

        var permissionDTOs = _mapper.Map<IEnumerable<CreateResponsePermissionDTO>>(permissions);
        return Ok(permissionDTOs);
    }
}

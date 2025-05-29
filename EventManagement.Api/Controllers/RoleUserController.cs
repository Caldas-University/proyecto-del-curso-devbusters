namespace EventManagement.Api.Controllers;

using EventManagement.Application.Contracts.Services;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class RoleUserController : ControllerBase
{
    private readonly IRoleUserServiceApp _roleUserService;
    private readonly IRoleServiceApp _roleService;
    private readonly IUserServiceApp _userService;
    private readonly IMapper _mapper;

    public RoleUserController(IRoleUserServiceApp roleUserService, IMapper mapper, IRoleServiceApp roleService, IUserServiceApp userService)
    {
        _roleUserService = roleUserService;
        _roleService = roleService;
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddRoleUser(RoleUserRequestDTO roleUserDTO)
    {
        if (roleUserDTO == null)
        {
            return BadRequest("Role user data is null");
        }

        var roleUserEntity = _mapper.Map<RoleUser>(roleUserDTO);
        if (roleUserEntity.idRole == Guid.Empty || roleUserEntity.idUser == Guid.Empty)
        {
            return BadRequest("Role ID and User ID cannot be empty");
        }

        // Check if the role and user exist
        var role = await _roleService.GetRoleByIdAsync(roleUserEntity.idRole);
        var user = await _userService.GetUserByIdAsync(roleUserEntity.idUser);

        if (role.id != roleUserEntity.idRole || user.id != roleUserEntity.idUser)
        {
            return BadRequest("Role or User does not exist");
        }

        var createdRoleUser = await _roleUserService.AssignRoleUserAsync(roleUserEntity);

        if (createdRoleUser == Guid.Empty)
        {
            return StatusCode(500, "An error occurred while creating the role user");
        }

        var responseRoleUserDTO = _mapper.Map<RoleUserResponseDTO>(roleUserEntity);
        return Ok(responseRoleUserDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleUserById(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid role user ID");
        }

        try
        {
            var roleUserEntity = await _roleUserService.GetRoleUserByIdAsync(id);
            var responseRoleUserDTO = _mapper.Map<RoleUserResponseDTO>(roleUserEntity);
            return Ok(responseRoleUserDTO);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Role user with ID {id} not found");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoleUsers()
    {
        try
        {
            var roleUsers = await _roleUserService.GetAllRoleUsersAsync();
            var responseRoleUserDTOs = _mapper.Map<IEnumerable<RoleUserResponseDTO>>(roleUsers);
            return Ok(responseRoleUserDTOs);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("No role users found");
        }
    }
}
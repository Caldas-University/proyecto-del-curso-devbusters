namespace EventManagement.Api.Controllers;

using EventManagement.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserServiceApp _userService;
    private readonly IMapper _mapper;

    public UserController(IUserServiceApp userService, IMapper mapper)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAsync(UserRequestDTO userDTO)
    {
        if (userDTO == null)
        {
            return BadRequest("User data is null");
        }

        var userEntity = _mapper.Map<User>(userDTO);
        var createdUserId = await _userService.UserAsync(userEntity);

        if (createdUserId == Guid.Empty)
        {
            return BadRequest("Failed to create user");
        }

        var responseUserDTO = _mapper.Map<UserResponseDTO>(userEntity);
        return Ok(responseUserDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid user ID");
        }

        var userEntity = await _userService.GetUserByIdAsync(id);
        if (userEntity == null)
        {
            return NotFound($"User with ID {id} not found");
        }

        var userDTO = _mapper.Map<UserResponseDTO>(userEntity);
        return Ok(userDTO);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var users = await _userService.GetAllUsersAsync();
        if (users == null || !users.Any())
        {
            return NotFound("No users found");
        }

        var userDTOs = _mapper.Map<IEnumerable<UserResponseDTO>>(users);
        return Ok(userDTOs);
    }
}

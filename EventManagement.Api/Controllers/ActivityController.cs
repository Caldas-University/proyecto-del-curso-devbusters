using EventManagement.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IActivityServiceApp _activityService;
    private readonly IMapper _mapper;

    public ActivityController(IActivityServiceApp activityService, IMapper mapper)
    {
        _activityService = activityService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddActivity(CreateRequestActivityDTO activityDTO)
    {
        if (activityDTO == null)
        {
            return BadRequest("Activity data is null");
        }

        var activityEntity = _mapper.Map<Activity>(activityDTO);
        var createdActivityId = await _activityService.CreateAsync(activityEntity);

        if (createdActivityId == Guid.Empty)
        {
            return BadRequest("Failed to create activity");
        }

        var responseDTO = _mapper.Map<CreateResponseActivityDTO>(activityEntity);
        return Ok(responseDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivityByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid activity ID");
        }

        var activity = await _activityService.GetByIdAsync(id);
        if (activity == null)
        {
            return NotFound($"Activity with ID {id} not found");
        }

        var responseDTO = _mapper.Map<CreateResponseActivityDTO>(activity);
        return Ok(responseDTO);
    }
}

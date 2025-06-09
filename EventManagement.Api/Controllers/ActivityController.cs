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

        try
        {
            var activityEntity = _mapper.Map<Activity>(activityDTO);
            var createdActivityId = await _activityService.CreateAsync(activityEntity);

            var responseDTO = _mapper.Map<CreateResponseActivityDTO>(activityEntity);
            return Ok(responseDTO);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message }); // 👈 muestra el mensaje de solapamiento
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ocurrió un error interno", detail = ex.Message });
        }
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

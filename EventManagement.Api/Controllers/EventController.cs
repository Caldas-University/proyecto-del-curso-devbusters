using EventManagement.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IEventServiceApp _EventService;
    private readonly IMapper _mapper;

    public EventController(IEventServiceApp EventService, IMapper mapper)
    {
        _mapper = mapper;
        _EventService = EventService;
    }

    [HttpPost]
    public IActionResult AddEvent(CreateRequestEventDTO eventDTO)
    {
        if (eventDTO == null)
        {
            return BadRequest("Event data is null");
        }

        var eventEntity = _mapper.Map<Event>(eventDTO);
        var createdEvent = _EventService.EventAsync(eventEntity);

        if (createdEvent == null)
        {
            return BadRequest("Failed to create event");
        }

        var responseEventDTO = _mapper.Map<CreateResponseEventDTO>(eventEntity);
        return Ok(responseEventDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid event ID");
        }

        var eventEntity = await _EventService.GetEventByIdAsync(id);
        if (eventEntity == null)
        {
            return NotFound($"Event with ID {id} not found");
        }

        var eventDTO = _mapper.Map<CreateResponseEventDTO>(eventEntity);
        return Ok(eventDTO);
    }
}

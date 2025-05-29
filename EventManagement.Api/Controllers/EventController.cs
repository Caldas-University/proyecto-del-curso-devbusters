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
    public async Task<IActionResult> AddEvent([FromBody] CreateRequestEventDTO eventDTO)
    {
        if (eventDTO == null)
            return BadRequest("Event data is null");

        var eventEntity = _mapper.Map<Event>(eventDTO);

        try
        {
            // Llamada asíncrona al servicio que crea el evento validando fechas
            var createdEventId = await _EventService.EventAsync(eventEntity);

            // Opcional: puedes cargar el evento completo si necesitas devolver más datos
            // var createdEvent = await _EventService.GetByIdAsync(createdEventId);

            var responseEventDTO = _mapper.Map<CreateResponseEventDTO>(eventEntity);
            return Ok(responseEventDTO);
        }
        catch (InvalidOperationException ex)
        {
            // Captura la excepción lanzada cuando hay solapamiento de fechas
            return Conflict(new { message = ex.Message });
        }
        catch (Exception)
        {
            // Para otros errores inesperados
            return StatusCode(500, "Internal server error");
        }
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

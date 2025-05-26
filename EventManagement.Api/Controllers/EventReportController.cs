using Microsoft.AspNetCore.Mvc;
using EventManagement.Application.Contracts.Services;
using EventManagement.Application.DTO;
using AutoMapper;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventReportController : ControllerBase
{
    private readonly IEventReportService _service;
    private readonly IMapper _mapper;

    public EventReportController(IEventReportService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventReportDto dto)
    {
        var entity = _mapper.Map<EventManagement.Domain.Entities.EventReport>(dto);
        await _service.AddReportAsync(entity);
        return Ok(new { message = "Reporte guardado exitosamente." });
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] string? eventId,
        [FromQuery] string? activityType,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var entities = await _service.GetReportsAsync(eventId, activityType, startDate, endDate);
        var dtos = _mapper.Map<IEnumerable<EventReportDto>>(entities);
        return Ok(dtos);
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary(
        [FromQuery] string? eventId,
        [FromQuery] string? activityType,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var summary = await _service.GetReportSummaryAsync(eventId, activityType, startDate, endDate);
        return Ok(summary);
    }

    [HttpGet("export/pdf")]
    public async Task<IActionResult> ExportPdf(
        [FromQuery] string? eventId,
        [FromQuery] string? activityType,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var entities = await _service.GetReportsAsync(eventId, activityType, startDate, endDate);
        var dtos = _mapper.Map<List<EventReportDto>>(entities);

        var summary = await _service.GetReportSummaryAsync(eventId, activityType, startDate, endDate);
        var pdfBytes = EventManagement.Api.Reports.EventReportPdfGenerator.Generate(dtos, summary);

        return File(pdfBytes, "application/pdf", "event-report.pdf");
    }
}
using Microsoft.AspNetCore.Mvc;
using EventManagement.Application.Contracts.Services;
using EventManagement.Application.DTO;
using EventManagement.Api.Reports;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventReportController : ControllerBase
{
    private readonly IEventReportService _service;

    public EventReportController(IEventReportService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventReportDto dto)
    {
        await _service.AddReportAsync(dto);
        return Ok(new { message = "Reporte guardado exitosamente." });
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] string? eventId,
        [FromQuery] string? activityType,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var result = await _service.GetReportsAsync(eventId, activityType, startDate, endDate);
        return Ok(result);
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
        var data = await _service.GetReportsAsync(eventId, activityType, startDate, endDate);
        var summary = await _service.GetReportSummaryAsync(eventId, activityType, startDate, endDate);

        var pdfBytes = EventReportPdfGenerator.Generate(data.ToList(), summary);

        return File(pdfBytes, "application/pdf", "event-report.pdf");
    }

}
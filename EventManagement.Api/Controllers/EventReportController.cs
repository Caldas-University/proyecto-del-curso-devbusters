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
        [FromQuery] Guid? Id,
        [FromQuery] string? activityType,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var entities = await _service.GetReportsAsync(Id, activityType, startDate, endDate);
        var dtos = _mapper.Map<IEnumerable<EventReportDto>>(entities);
        return Ok(dtos);
    }

    [HttpGet("summary")]
    public async Task<IActionResult> GetSummary(
        [FromQuery] Guid? Id,
        [FromQuery] string? activityType,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var summary = await _service.GetReportSummaryAsync(Id, activityType, startDate, endDate);
        return Ok(summary);
    }

    [HttpGet("export/pdf")]
    public async Task<IActionResult> ExportPdf(
        [FromQuery] Guid? Id,
        [FromQuery] string? activityType,
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var entities = await _service.GetReportsAsync(Id, activityType, startDate, endDate);
        var dtos = _mapper.Map<List<EventReportDto>>(entities);

        var summary = await _service.GetReportSummaryAsync(Id, activityType, startDate, endDate);
        var pdfBytes = Reports.EventReportPdfGenerator.Generate(dtos, summary);

        return File(pdfBytes, "application/pdf", "event-report.pdf");
    }

    [HttpGet("export/excel")]
    public async Task<IActionResult> ExportExcel(
    [FromQuery] Guid? id,
    [FromQuery] string? activityType,
    [FromQuery] DateTime? startDate,
    [FromQuery] DateTime? endDate)
    {
        var entities = await _service.GetReportsAsync(id, activityType, startDate, endDate);
        var dtos = _mapper.Map<List<EventReportDto>>(entities);

        var summary = await _service.GetReportSummaryAsync(id, activityType, startDate, endDate);
        var excelBytes = Reports.EventReportExcelGenerator.Generate(dtos, summary);

        return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "event-report.xlsx");
    }
}
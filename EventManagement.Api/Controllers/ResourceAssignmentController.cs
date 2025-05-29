using EventManagement.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourceAssignmentController : ControllerBase
{
    private readonly IResourceAssignmentServiceApp _assignmentService;
    private readonly IMapper _mapper;

    public ResourceAssignmentController(IResourceAssignmentServiceApp assignmentService, IMapper mapper)
    {
        _mapper = mapper;
        _assignmentService = assignmentService;
    }

    [HttpPost]
    public IActionResult AddAssignment(CreateRequestResourceAssignmentDTO assignmentDTO)
    {
        if (assignmentDTO == null)
        {
            return BadRequest("Assignment data is null");
        }

        var assignmentEntity = _mapper.Map<ResourceAssignment>(assignmentDTO);
        var createdAssignment = _assignmentService.ResourceAssignmentAsync(assignmentEntity);

        if (createdAssignment == null)
        {
            return BadRequest("Failed to assign resource");
        }

        var responseDTO = _mapper.Map<CreateResponseResourceAssignmentDTO>(assignmentEntity);
        return Ok(responseDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetResourceAssignmentByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("Invalid assignment ID");
        }

        var assignmentEntity = await _assignmentService.GetResourceAssignmentByIdAsync(id);
        if (assignmentEntity == null)
        {
            return NotFound($"Assignment with ID {id} not found");
        }

        var assignmentDTO = _mapper.Map<CreateResponseResourceAssignmentDTO>(assignmentEntity);
        return Ok(assignmentDTO);
    }
}

using AutoMapper;
using EventManagement.Application.Contracts.Services;
using EventManagement.Application.DTO;
using EventManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourceController : ControllerBase
{
    private readonly IResourceServiceApp _ResourceService;
    private readonly IMapper _mapper;

    public ResourceController(IResourceServiceApp ResourceService, IMapper mapper)
    {
        _ResourceService = ResourceService;
        _mapper = mapper;
    }

    // POST api/resource 
    [HttpPost]
    public IActionResult AddResource(CreateRequestResourceDTO resourceDTO)
    {
        
        if (resourceDTO == null)
        {
            return BadRequest("Resource data is null");
        }

        var resourceEntity = _mapper.Map<Resource>(resourceDTO);
        var createdResource = _ResourceService.ResourceAsync(resourceEntity);

        if (createdResource == null)
        {
            return BadRequest("Failed to create resource");
        }

        var responseResourceDTO = _mapper.Map<CreateResponseResourceDTO>(resourceEntity);
        return Ok(responseResourceDTO);
        
    }

    // GET api/resource/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetResourceByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest("Invalid resource ID");

        var resource = await _ResourceService.GetResourceByIdAsync(id);
        if (resource == null)
            return NotFound($"Resource with ID {id} not found");

        var resourceDTO = _mapper.Map<CreateResponseResourceDTO>(resource);
        return Ok(resourceDTO);
    }
}

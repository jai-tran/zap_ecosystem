using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Locations.v1.Commands;
using ZAP.Ecosystem.Application.CRM.Features.Locations.v1.DTOs;
using ZAP.Ecosystem.Application.CRM.Features.Locations.v1.Queries;

namespace ZAP.Ecosystem.API.CRM.Features.Locations.v1.Controllers;

[ApiController]
[Route("api/v1/catalog/locations")]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromBody] LocationListRequestDto request)
    {
        var response = await _mediator.Send(new GetLocationListQuery { Request = request });
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _mediator.Send(new GetLocationByIdQuery { Id = id });
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationRequestDto request)
    {
        var response = await _mediator.Send(new CreateLocationCommand { Request = request });
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLocationRequestDto request)
    {
        var response = await _mediator.Send(new UpdateLocationCommand { Id = id, Request = request });
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteLocationCommand { Id = id });
        return Ok(response);
    }
}

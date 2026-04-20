using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Commands;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Queries;

namespace ZAP.Ecosystem.API.CRM.Features.Collections.v1.Controllers;

[ApiController]
[Route("api/v1/catalog/collections")]
[Route("api/collections")]
public class CollectionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CollectionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("list")]
    public async Task<IActionResult> List([FromBody] CollectionListRequestDto request)
    {
        var result = await _mediator.Send(new GetCollectionListQuery { Request = request });
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetCollectionByIdQuery(id));
        if (result == null)
            return NotFound(new { message = "Collection not found" });

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCollectionRequestDto request)
    {
        var result = await _mediator.Send(new CreateCollectionCommand { Request = request });
        return CreatedAtAction(nameof(GetById), new { id = result.id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCollectionRequestDto request)
    {
        try
        {
            var result = await _mediator.Send(new UpdateCollectionCommand(id, request));
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteCollectionCommand(id));
        if (!result)
            return NotFound(new { message = "Collection not found" });

        return Ok(new { success = true });
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.DTOs;
using ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Queries;
using ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Commands;

namespace ZAP.Ecosystem.API.CRM.Features.ModifierGroups.v1.Controllers;

[ApiController]
[Route("api/v1/catalog/modifier_groups")]
[Route("api/modifiergroups")]
[Route("api/modifier_groups")]
public class ModifierGroupsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ModifierGroupsController(IMediator mediator) => _mediator = mediator;

    [HttpPost("list")]
    public async Task<IActionResult> List([FromBody] ModifierGroupListRequestDto? request)
    {
        var result = await _mediator.Send(new GetModifierGroupsQuery { Request = request ?? new() });
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(System.Guid id)
    {
        var result = await _mediator.Send(new GetModifierGroupByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateModifierGroupCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(System.Guid id, [FromBody] UpdateModifierGroupCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(System.Guid id)
    {
        var result = await _mediator.Send(new DeleteModifierGroupCommand { Id = id });
        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Patch(System.Guid id, [FromBody] UpdateModifierGroupCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

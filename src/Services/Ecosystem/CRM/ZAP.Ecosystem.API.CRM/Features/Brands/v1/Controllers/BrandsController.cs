using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Brands.v1.DTOs;
using ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Queries;
using ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Commands;

namespace ZAP.Ecosystem.API.CRM.Features.Brands.v1.Controllers;

[ApiController]
[Route("api/v1/catalog/brands")]
[Route("api/brands")]
public class BrandsController : ControllerBase
{
    private readonly IMediator _mediator;
    public BrandsController(IMediator mediator) => _mediator = mediator;

    [HttpPost("list")]
    public async Task<IActionResult> List([FromBody] BrandListRequestDto request)
    {
        var result = await _mediator.Send(new GetBrandListQuery { Request = request });
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(System.Guid id)
    {
        var result = await _mediator.Send(new GetBrandByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBrandCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(System.Guid id, [FromBody] UpdateBrandCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(System.Guid id)
    {
        var result = await _mediator.Send(new DeleteBrandCommand { Id = id });
        return Ok(result);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Patch(System.Guid id, [FromBody] UpdateBrandCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

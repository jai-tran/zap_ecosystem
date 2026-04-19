using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Products.v1.Commands;
using ZAP.Ecosystem.Application.CRM.Features.Products.v1.DTOs;
using ZAP.Ecosystem.Application.CRM.Features.Products.v1.Queries;

namespace ZAP.Ecosystem.API.CRM.Features.Products.v1.Controllers;

[ApiController]
[Route("api/v1/catalog/products")]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator) => _mediator = mediator;

    [HttpPost("list")]
    public async Task<IActionResult> List([FromBody] ProductListRequestDto request)
    {
        var result = await _mediator.Send(new GetProductListQuery { Request = request });
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(System.Guid id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id.ToString()));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(System.Guid id, [FromBody] UpdateProductCommand command)
    {
        if (id.ToString() != command.Id) return BadRequest("ID mismatch");
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(System.Guid id)
    {
        var result = await _mediator.Send(new DeleteProductCommand { Id = id });
        return Ok(result);
    }
}

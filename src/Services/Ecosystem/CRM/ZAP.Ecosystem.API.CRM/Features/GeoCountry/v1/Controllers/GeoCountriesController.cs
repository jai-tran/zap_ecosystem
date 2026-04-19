using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.DTOs;
using ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.Queries;
using ZAP.Ecosystem.Application.CRM.Features.GeoCountry.v1.Commands;

namespace ZAP.Ecosystem.API.CRM.Features.GeoCountry.v1.Controllers;

[ApiController]
[Route("api/v1/catalog/geo_countries")]
public class GeoCountriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public GeoCountriesController(IMediator mediator) => _mediator = mediator;

    [HttpPost("list")]
    public async Task<IActionResult> List([FromBody] GeoCountryListRequestDto request)
    {
        var result = await _mediator.Send(new GetGeoCountryListQuery { Request = request });
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetGeoCountryByIdQuery { id = id });
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGeoCountryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateGeoCountryCommand command)
    {
        if (id != command.id) return BadRequest("ID mismatch");
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteGeoCountryCommand { id = id });
        return Ok(result);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, [FromBody] UpdateGeoCountryCommand command)
    {
        if (id != command.id) return BadRequest("ID mismatch");
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

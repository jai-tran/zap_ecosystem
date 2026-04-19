using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Application.CRM.Features.Units.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.Queries;

public class GetUnitByIdQueryHandler : IRequestHandler<GetUnitByIdQuery, object>
{
    private readonly IUnitRepository _repository;

    public GetUnitByIdQueryHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
    {
        var unit = await _repository.GetByIdAsync(request.Id);
        if (unit == null)
            return CrmResponse.NotFound("Unit");

        var dto = new UnitDto
        {
            id = unit.id,
            code = unit.code ?? string.Empty,
            name = unit.name ?? string.Empty,
            precision = unit.precision,
            is_active = unit.is_active,
            created_at = unit.created_at,
            updated_at = unit.updated_at
        };

        return CrmResponse.Ok(dto);
    }
}

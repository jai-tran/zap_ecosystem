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
    private readonly ICurrentUserService _currentUserService;

    public GetUnitByIdQueryHandler(IUnitRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(GetUnitByIdQuery request, CancellationToken cancellationToken)
    {
        var localeId = _currentUserService.LocaleId;

        var unit = await _repository.GetByIdAsync(request.Id);
        if (unit == null)
            return CrmResponse.NotFound("Unit");

        var dto = new UnitDto
        {
            id = unit.id,
            tenant_id = null,
            code = unit.code ?? string.Empty,
            name = unit.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name ?? unit.name ?? string.Empty,
            symbol = unit.abbreviation,
            precision = unit.precision,
            status_id = unit.status_id,
            status_code = unit.status?.code,
            status_name = unit.status?.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name ?? unit.status?.code,
            is_active = unit.is_active,
            created_at = unit.created_at,
            updated_at = unit.updated_at
        };

        return CrmResponse.Ok(dto);
    }
}

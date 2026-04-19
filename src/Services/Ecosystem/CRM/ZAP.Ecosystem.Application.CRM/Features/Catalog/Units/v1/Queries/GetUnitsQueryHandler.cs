using MediatR;
using ZAP.Ecosystem.Application.CRM.Features.Units.v1.DTOs;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.Queries;

public class GetUnitsQueryHandler : IRequestHandler<GetUnitsQuery, object>
{
    private readonly IUnitRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public GetUnitsQueryHandler(IUnitRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(GetUnitsQuery request, CancellationToken cancellationToken)
    {
        Guid? tenantId = Guid.TryParse(_currentUserService.TenantId, out var g) ? g : null;
        var localeId = _currentUserService.LocaleId;

        var (items, total) = await _repository.GetPagedAsync(
            request.Request.PageIndex,
            request.Request.PageSize,
            tenantId,
            request.Request.Search,
            request.Request.Filters?.StatusId,
            request.Request.Filters?.Precision,
            request.Request.Sort?.Field ?? "name",
            request.Request.Sort?.Descending ?? false);

        var dtos = items.Select(x => new UnitDto
        {
            id = x.id,
            tenant_id = null,
            code = x.code ?? string.Empty,
            name = x.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name ?? x.name ?? string.Empty,
            abbreviation = x.abbreviation,
            precision = x.precision,
            status_id = x.is_active ? 1 : 0,
            status_code = x.is_active ? "ACTIVE" : "INACTIVE",
            status_name = x.is_active ? "Active" : "Inactive",
            is_active = x.is_active
        }).ToList();

        return CrmResponse.Paged(new PagedResult<UnitDto>(dtos, total, request.Request.PageIndex, request.Request.PageSize));
    }
}

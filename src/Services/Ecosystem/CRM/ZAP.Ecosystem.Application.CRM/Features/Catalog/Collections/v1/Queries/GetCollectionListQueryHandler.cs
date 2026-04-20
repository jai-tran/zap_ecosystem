using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;
using ZAP.Ecosystem.Application.CRM.Interfaces;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Queries;

public class GetCollectionListQueryHandler : IRequestHandler<GetCollectionListQuery, object>
{
    private readonly ICollectionRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public GetCollectionListQueryHandler(ICollectionRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(GetCollectionListQuery request, CancellationToken cancellationToken)
    {
        Guid? tenantId = Guid.TryParse(_currentUserService.TenantId, out var g) ? g : null;
        var localeId = _currentUserService.LocaleId;

        var (items, totalCount) = await _repository.GetPagedAsync(
            request.Request.PageIndex,
            request.Request.PageSize,
            tenantId,
            request.Request.Search,
            request.Request.Filters?.StatusId,
            request.Request.Sort?.Field ?? "created_at",
            request.Request.Sort?.Descending ?? true
        );

        var dtos = items.Select(c => new CollectionDto
        {
            id = c.id,
            serial_id = c.serial_id,
            tenant_id = c.tenant_id,
            name = c.name,
            slug = c.slug,
            description_html = c.description_html,
            banner_url = c.banner_url,
            status_id = c.status_id,
            status_code = c.status?.code,
            status_name = c.status?.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name ?? c.status?.code,
            sort_order = c.sort_order,
            created_at = c.created_at,
            updated_at = c.updated_at,
            items = c.items?.Select(i => new CollectionItemDto
            {
                product_id = i.product_id,
                sort_order = i.sort_order
            }).ToList() ?? new()
        }).ToList();

        return CrmResponse.Ok(new
        {
            page_index = request.Request.PageIndex,
            page_size = request.Request.PageSize,
            total_items = totalCount,
            items = dtos
        });
    }
}


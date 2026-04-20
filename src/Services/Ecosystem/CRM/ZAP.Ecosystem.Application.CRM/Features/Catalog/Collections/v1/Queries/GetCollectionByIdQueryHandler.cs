using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Queries;

public class GetCollectionByIdQueryHandler : IRequestHandler<GetCollectionByIdQuery, object>
{
    private readonly ICollectionRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public GetCollectionByIdQueryHandler(ICollectionRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(GetCollectionByIdQuery request, CancellationToken cancellationToken)
    {
        var tenantId = Guid.TryParse(_currentUserService.TenantId, out var tid) ? tid : (Guid?)null;
        var collection = await _repository.GetByIdAsync(request.Id);

        if (collection == null || collection.tenant_id != tenantId)
            return CrmResponse.NotFound("Collection");

        var dto = new CollectionDto
        {
            id = collection.id,
            serial_id = collection.serial_id,
            tenant_id = collection.tenant_id,
            name = collection.name,
            slug = collection.slug,
            description_html = collection.description_html,
            banner_url = collection.banner_url,
            status_id = collection.status_id,
            status_code = collection.status?.code,
            status_name = collection.status?.translations?.FirstOrDefault()?.name ?? collection.status?.code,
            sort_order = collection.sort_order,
            created_at = collection.created_at,
            updated_at = collection.updated_at,
            items = collection.items?.Select(i => new CollectionItemDto
            {
                product_id = i.product_id,
                sort_order = i.sort_order
            }).ToList() ?? new()
        };

        return CrmResponse.Ok(dto);
    }
}

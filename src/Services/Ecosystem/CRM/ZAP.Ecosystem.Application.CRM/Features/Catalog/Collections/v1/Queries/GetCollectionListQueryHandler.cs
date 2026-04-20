using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Queries;

public class GetCollectionListQueryHandler : IRequestHandler<GetCollectionListQuery, object>
{
    private readonly ICollectionRepository _repository;

    public GetCollectionListQueryHandler(ICollectionRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(GetCollectionListQuery request, CancellationToken cancellationToken)
    {
        var (items, totalCount) = await _repository.GetPagedAsync(
            request.Request.PageIndex,
            request.Request.PageSize,
            request.Request.Search
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
            status_code = c.status_code,
            status_name = c.status_name,
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


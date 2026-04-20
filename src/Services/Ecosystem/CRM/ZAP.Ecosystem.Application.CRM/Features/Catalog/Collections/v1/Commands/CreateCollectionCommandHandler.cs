using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Commands;

public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand, CollectionDto>
{
    private readonly ICollectionRepository _repository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMediator _mediator;

    public CreateCollectionCommandHandler(ICollectionRepository repository, ICurrentUserService currentUserService, IMediator mediator)
    {
        _repository = repository;
        _currentUserService = currentUserService;
        _mediator = mediator;
    }

    public async Task<CollectionDto> Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
    {
        var tenantId = Guid.TryParse(_currentUserService.TenantId, out var tid) ? tid : (Guid?)null;
        var collection = new Collection
        {
            id = Guid.NewGuid(),
            tenant_id = tenantId,
            name = request.Request.name,
            slug = request.Request.slug,
            description_html = request.Request.description_html,
            banner_url = request.Request.banner_url,
            sort_order = request.Request.sort_order,
            status_id = request.Request.status_id,
            created_at = DateTime.UtcNow
        };

        if (request.Request.items != null && request.Request.items.Any())
        {
            foreach (var item in request.Request.items)
            {
                collection.items.Add(new CollectionItem
                {
                    collection_id = collection.id,
                    product_id = item.product_id,
                    sort_order = item.sort_order
                });
            }
        }

        await _repository.CreateAsync(collection);

        return await _mediator.Send(new Queries.GetCollectionByIdQuery(collection.id), cancellationToken);
    }
}


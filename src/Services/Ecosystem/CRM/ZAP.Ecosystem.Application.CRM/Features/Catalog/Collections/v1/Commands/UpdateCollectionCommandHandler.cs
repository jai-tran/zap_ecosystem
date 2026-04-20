using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Commands;

public class UpdateCollectionCommandHandler : IRequestHandler<UpdateCollectionCommand, CollectionDto>
{
    private readonly ICollectionRepository _repository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMediator _mediator;

    public UpdateCollectionCommandHandler(ICollectionRepository repository, ICurrentUserService currentUserService, IMediator mediator)
    {
        _repository = repository;
        _currentUserService = currentUserService;
        _mediator = mediator;
    }

    public async Task<CollectionDto> Handle(UpdateCollectionCommand request, CancellationToken cancellationToken)
    {
        var tenantId = Guid.TryParse(_currentUserService.TenantId, out var tid) ? tid : (Guid?)null;
        var collection = await _repository.GetByIdAsync(request.Id);

        if (collection == null || collection.tenant_id != tenantId)
            throw new Exception("Collection not found");

        collection.name = request.Request.name;
        collection.slug = request.Request.slug;
        collection.description_html = request.Request.description_html;
        collection.banner_url = request.Request.banner_url;
        collection.sort_order = request.Request.sort_order;
        collection.status_id = request.Request.status_id;
        collection.updated_at = DateTime.UtcNow;

        // Clear existing items
        collection.items.Clear();
        
        // Add new items
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

        await _repository.UpdateAsync(collection);

        return await _mediator.Send(new Queries.GetCollectionByIdQuery(collection.id), cancellationToken);
    }
}


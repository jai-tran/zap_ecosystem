using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Catalog.Collections.v1.Commands;

public class DeleteCollectionCommandHandler : IRequestHandler<DeleteCollectionCommand, bool>
{
    private readonly ICollectionRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public DeleteCollectionCommandHandler(ICollectionRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<bool> Handle(DeleteCollectionCommand request, CancellationToken cancellationToken)
    {
        var tenantId = Guid.TryParse(_currentUserService.TenantId, out var tid) ? tid : (Guid?)null;
        var collection = await _repository.GetByIdAsync(request.Id);

        if (collection == null || collection.tenant_id != tenantId)
            return false;

        await _repository.DeleteAsync(collection.id);
        return true;
    }
}


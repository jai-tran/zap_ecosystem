using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Locations.v1.Commands;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, object>
{
    private readonly ILocationRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public DeleteLocationCommandHandler(ILocationRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var tenantId = Guid.TryParse(_currentUserService.TenantId, out var tid) ? tid : (Guid?)null;
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null || entity.tenant_id != tenantId)
            return CrmResponse.NotFound("Location");

        await _repository.DeleteAsync(entity.id);

        return CrmResponse.Ok(null);
    }
}

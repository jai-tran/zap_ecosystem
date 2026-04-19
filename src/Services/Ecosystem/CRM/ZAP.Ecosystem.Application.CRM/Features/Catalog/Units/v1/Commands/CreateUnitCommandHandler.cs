using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.Commands;

public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, object>
{
    private readonly IUnitRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public CreateUnitCommandHandler(IUnitRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = new UomItem
        {
            code = request.Code ?? string.Empty,
            name = request.Name ?? string.Empty,
            precision = request.Precision,
            is_active = request.IsActive,
            created_at = DateTime.UtcNow
        };

        await _repository.CreateAsync(unit);

        return CrmResponse.Created(new { id = unit.id });
    }
}

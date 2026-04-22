using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.Commands;

public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand, object>
{
    private readonly IUnitRepository _repository;

    public UpdateUnitCommandHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = await _repository.GetByIdAsync(request.Id);
        if (unit == null)
            return CrmResponse.NotFound("Unit");

        if (request.Code != null) unit.code = request.Code;
        if (request.Name != null) unit.name = request.Name;
        if (request.IsActive.HasValue) unit.is_active = request.IsActive.Value;
        if (request.StatusId.HasValue) unit.status_id = request.StatusId.Value;
        if (request.Precision.HasValue) unit.precision = request.Precision.Value;
        if (request.Symbol != null) unit.abbreviation = request.Symbol;
        
        unit.updated_at = DateTime.UtcNow;

        await _repository.UpdateAsync(unit);

        return CrmResponse.Updated(new { id = unit.id });
    }
}

using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Units.v1.Commands;

public class DeleteUnitCommandHandler : IRequestHandler<DeleteUnitCommand, object>
{
    private readonly IUnitRepository _repository;

    public DeleteUnitCommandHandler(IUnitRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(DeleteUnitCommand request, CancellationToken cancellationToken)
    {
        var unit = await _repository.GetByIdAsync(request.Id);
        if (unit == null)
            return CrmResponse.NotFound("Unit");

        await _repository.DeleteAsync(request.Id);

        return CrmResponse.Ok(new { id = request.Id }, "Deleted successfully");
    }
}

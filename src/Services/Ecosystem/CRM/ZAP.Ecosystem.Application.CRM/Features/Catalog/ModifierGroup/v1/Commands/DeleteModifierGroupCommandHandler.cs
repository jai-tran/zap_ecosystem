using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Commands
{
    public class DeleteModifierGroupCommandHandler : IRequestHandler<DeleteModifierGroupCommand, object>
    {
        private readonly IModifierGroupRepository _repository;

        public DeleteModifierGroupCommandHandler(IModifierGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(DeleteModifierGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CrmResponse.NotFound("Modifier Group");

            await _repository.DeleteAsync(request.Id);

            return CrmResponse.Ok(new { id = request.Id }, "Modifier group deleted successfully");
        }
    }
}

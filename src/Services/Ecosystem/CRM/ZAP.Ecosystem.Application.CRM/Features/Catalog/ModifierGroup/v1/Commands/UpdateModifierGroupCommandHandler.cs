using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Commands
{
    public class UpdateModifierGroupCommandHandler : IRequestHandler<UpdateModifierGroupCommand, object>
    {
        private readonly IModifierGroupRepository _repository;

        public UpdateModifierGroupCommandHandler(IModifierGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(UpdateModifierGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CrmResponse.NotFound("Modifier Group");

            if (request.Name != null) entity.name = request.Name;
            if (request.Description != null) entity.description = request.Description;
            if (request.ImageUrl != null) entity.image_url = request.ImageUrl;
            if (request.MinSelection.HasValue) entity.min_selection = request.MinSelection.Value;
            if (request.MaxSelection.HasValue) entity.max_selection = request.MaxSelection.Value;
            if (request.IsRequired.HasValue) entity.is_required = request.IsRequired.Value;
            if (request.SortOrder.HasValue) entity.sort_order = request.SortOrder.Value;
            if (request.StatusId.HasValue) entity.status_id = request.StatusId.Value;

            await _repository.UpdateAsync(entity);

            return CrmResponse.Updated(new { id = entity.id });
        }
    }
}

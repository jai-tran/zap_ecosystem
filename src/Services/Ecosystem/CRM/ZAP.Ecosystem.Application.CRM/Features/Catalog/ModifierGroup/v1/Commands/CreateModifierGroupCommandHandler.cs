using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;
using ZAP.Ecosystem.Shared.Interfaces;

namespace ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Commands
{
    public class CreateModifierGroupCommandHandler : IRequestHandler<CreateModifierGroupCommand, object>
    {
        private readonly IModifierGroupRepository _repository;
        private readonly ICurrentUserService _currentUserService;

        public CreateModifierGroupCommandHandler(IModifierGroupRepository repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task<object> Handle(CreateModifierGroupCommand request, CancellationToken cancellationToken)
        {
            Guid? tenantId = Guid.TryParse(_currentUserService.TenantId, out var g) ? g : null;

            var entity = new ZAP.Ecosystem.Domain.CRM.ModifierGroup
            {
                id = Guid.NewGuid(),
                tenant_id = tenantId ?? Guid.Empty,
                name = request.Name,
                description = request.Description,
                image_url = request.ImageUrl,
                min_selection = request.MinSelection,
                max_selection = request.MaxSelection,
                is_required = request.IsRequired,
                sort_order = request.SortOrder,
                status_id = request.StatusId
            };

            await _repository.CreateAsync(entity);

            return CrmResponse.Created(new { id = entity.id });
        }
    }
}

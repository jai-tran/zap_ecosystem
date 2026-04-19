using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;
using ZAP.Ecosystem.Shared.Interfaces;

namespace ZAP.Ecosystem.Application.CRM.Features.ModifierGroup.v1.Queries
{
    public class GetModifierGroupByIdQueryHandler : IRequestHandler<GetModifierGroupByIdQuery, object>
    {
        private readonly IModifierGroupRepository _repository;
        private readonly ICurrentUserService _currentUserService;

        public GetModifierGroupByIdQueryHandler(IModifierGroupRepository repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task<object> Handle(GetModifierGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CrmResponse.NotFound("Modifier Group");

            var localeId = _currentUserService.LocaleId;

            var dto = new ModifierGroupDto
            {
                id = entity.id,
                serial_id = entity.serial_id,
                tenant_id = entity.tenant_id,
                name = entity.name,
                min_selection = entity.min_selection,
                max_selection = entity.max_selection,
                is_required = entity.is_required,
                sort_order = entity.sort_order,
                status_id = entity.status_id,
                status_code = entity.status?.code,
                status_name = entity.status?.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name ??
                              entity.status?.translations?.FirstOrDefault(t => t.locale_id == 1)?.name
            };

            return CrmResponse.Ok(dto);
        }
    }
}

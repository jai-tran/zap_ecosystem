using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Locations.v1.Commands;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, object>
{
    private readonly ILocationRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public UpdateLocationCommandHandler(ILocationRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var tenantId = Guid.TryParse(_currentUserService.TenantId, out var tid) ? tid : (Guid?)null;
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity == null || entity.tenant_id != tenantId)
            return CrmResponse.NotFound("Location");

        entity.name = request.Request.name;
        entity.location_code = request.Request.location_code ?? string.Empty;
        entity.business_name = request.Request.business_name ?? string.Empty;
        entity.description = request.Request.description;
        entity.status_id = request.Request.status_id;
        entity.is_active = request.Request.is_active;
        entity.location_type_id = request.Request.location_type_id;
        entity.address_line_1 = request.Request.address_line_1;
        entity.address_line_2 = request.Request.address_line_2;
        entity.city = request.Request.city;
        entity.state = request.Request.state;
        entity.country_id = request.Request.country_id;
        entity.province_id = request.Request.province_id;
        entity.district_id = request.Request.district_id;
        entity.ward_id = request.Request.ward_id;
        entity.zipcode = request.Request.zipcode;
        entity.phone_number = request.Request.phone_number;
        entity.email = request.Request.email;
        entity.website = request.Request.website;
        entity.logo_url = request.Request.logo_url;
        entity.cover_image_url = request.Request.cover_image_url;
        entity.brand_color = request.Request.brand_color;
        entity.timezone = request.Request.timezone;
        entity.latitude = request.Request.latitude;
        entity.longitude = request.Request.longitude;
        entity.operating_hours = request.Request.operating_hours;
        entity.parent_location_id = request.Request.parent_location_id;
        entity.updated_at = DateTime.UtcNow;

        await _repository.UpdateAsync(entity);

        return CrmResponse.Ok(new { id = entity.id });
    }
}

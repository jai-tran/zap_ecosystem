using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Locations.v1.Commands;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, object>
{
    private readonly ILocationRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public CreateLocationCommandHandler(ILocationRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var tenantId = Guid.TryParse(_currentUserService.TenantId, out var tid) ? tid : (Guid?)null;

        var entity = new Location
        {
            id = Guid.NewGuid(),
            tenant_id = tenantId,
            name = request.Request.name,
            location_code = request.Request.location_code ?? string.Empty,
            business_name = request.Request.business_name ?? string.Empty,
            description = request.Request.description,
            status_id = request.Request.status_id,
            is_active = request.Request.is_active,
            location_type_id = request.Request.location_type_id,
            address_line_1 = request.Request.address_line_1,
            address_line_2 = request.Request.address_line_2,
            city = request.Request.city,
            state = request.Request.state,
            country_id = request.Request.country_id,
            province_id = request.Request.province_id,
            district_id = request.Request.district_id,
            ward_id = request.Request.ward_id,
            zipcode = request.Request.zipcode,
            phone_number = request.Request.phone_number,
            email = request.Request.email,
            website = request.Request.website,
            logo_url = request.Request.logo_url,
            cover_image_url = request.Request.cover_image_url,
            brand_color = request.Request.brand_color,
            timezone = request.Request.timezone,
            latitude = request.Request.latitude,
            longitude = request.Request.longitude,
            operating_hours = request.Request.operating_hours,
            parent_location_id = request.Request.parent_location_id,
            created_at = DateTime.UtcNow,
            updated_at = DateTime.UtcNow
        };

        await _repository.CreateAsync(entity);

        return CrmResponse.Ok(new { id = entity.id });
    }
}

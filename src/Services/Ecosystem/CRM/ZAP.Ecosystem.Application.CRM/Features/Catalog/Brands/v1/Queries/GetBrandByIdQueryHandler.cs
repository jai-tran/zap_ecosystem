using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using BrandDto = ZAP.Ecosystem.Application.CRM.Features.Brands.v1.DTOs.BrandDto;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Queries;

public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, object>
{
    private readonly IBrandRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public GetBrandByIdQueryHandler(IBrandRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id);
        if (brand == null)
            return CrmResponse.NotFound("Brand");

        var localeId = _currentUserService.LocaleId;

        var dto = new BrandDto
        {
            id = brand.id,
            serial_id = brand.serial_id,
            tenant_id = brand.tenant_id,
            brand_code = brand.brand_code,
            name = brand.name ?? string.Empty,
            business_name = brand.business_name,
            slug = brand.slug ?? string.Empty,
            description = brand.description,
            short_description = brand.short_description,
            logo_url = brand.logo_url,
            banner_url = brand.banner_url,
            cover_image_url = brand.cover_image_url,
            brand_color = brand.brand_color,
            website_url = brand.website_url,
            status_id = brand.status_id,
            status_code = brand.status?.code,
            status_name = brand.status?.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name
                       ?? brand.status?.translations?.FirstOrDefault(t => t.locale_id == 1)?.name,
            is_featured = brand.is_featured,
            is_premium = brand.is_premium,
            display_initial = brand.display_initial,
            created_at = brand.created_at,
            updated_at = brand.updated_at
        };

        return CrmResponse.Ok(dto);
    }
}

using MediatR;
using BrandDto = ZAP.Ecosystem.Application.CRM.Features.Brands.v1.DTOs.BrandDto;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Queries;

public class GetBrandListQueryHandler : IRequestHandler<GetBrandListQuery, object>
{
    private readonly IBrandRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public GetBrandListQueryHandler(IBrandRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(GetBrandListQuery request, CancellationToken cancellationToken)
    {
        System.Guid? tenantId = System.Guid.TryParse(_currentUserService.TenantId, out var g) ? g : null;
        var localeId = _currentUserService.LocaleId;

        var (items, total) = await _repository.GetPagedAsync(
            request.Request.PageIndex,
            request.Request.PageSize,
            tenantId,
            request.Request.Search,
            request.Request.Filters?.StatusId,
            request.Request.Sort?.Field ?? "created_at",
            request.Request.Sort?.Descending ?? true);

        var dtos = items.Select(x => new BrandDto
        {
            id = x.id,
            serial_id = x.serial_id,
            tenant_id = x.tenant_id,
            brand_code = x.brand_code,
            name = x.name ?? string.Empty,
            business_name = x.business_name,
            slug = x.slug ?? string.Empty,
            description = x.description,
            short_description = x.short_description,
            logo_url = x.logo_url,
            banner_url = x.banner_url,
            cover_image_url = x.cover_image_url,
            brand_color = x.brand_color,
            website_url = x.website_url,
            status_id = x.status_id,
            status_code = x.status?.code,
            status_name = x.status?.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name
                       ?? x.status?.translations?.FirstOrDefault(t => t.locale_id == 1)?.name,
            is_featured = x.is_featured,
            is_premium = x.is_premium,
            display_initial = x.display_initial,
            created_at = x.created_at,
            updated_at = x.updated_at
        }).ToList();

        return CrmResponse.Paged(new PagedResult<BrandDto>(dtos, total, request.Request.PageIndex, request.Request.PageSize));
    }
}

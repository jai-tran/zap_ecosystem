using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Commands;

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, object>
{
    private readonly IBrandRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public CreateBrandCommandHandler(IBrandRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        Guid? tenantId = Guid.TryParse(_currentUserService.TenantId, out var g) ? g : null;

        var brand = new Brand
        {
            id = Guid.NewGuid(),
            tenant_id = tenantId,
            name = request.Name ?? string.Empty,
            business_name = request.BusinessName,
            brand_code = request.BrandCode,
            slug = request.Slug ?? string.Empty,
            description = request.Description,
            short_description = request.ShortDescription,
            logo_url = request.LogoUrl,
            banner_url = request.BannerUrl,
            cover_image_url = request.CoverImageUrl,
            brand_color = request.BrandColor,
            website_url = request.WebsiteUrl,
            status_id = request.StatusId,
            is_featured = request.IsFeatured,
            is_premium = request.IsPremium,
            created_at = DateTime.UtcNow
        };

        await _repository.CreateAsync(brand);

        return CrmResponse.Created(new { id = brand.id });
    }
}

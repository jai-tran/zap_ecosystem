using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Commands;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, object>
{
    private readonly IBrandRepository _repository;

    public UpdateBrandCommandHandler(IBrandRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var brand = await _repository.GetByIdAsync(request.Id);
        if (brand == null)
            return CrmResponse.NotFound("Brand");

        brand.name = request.Name ?? brand.name;
        brand.business_name = request.BusinessName ?? brand.business_name;
        brand.brand_code = request.BrandCode ?? brand.brand_code;
        brand.slug = request.Slug ?? brand.slug;
        brand.description = request.Description ?? brand.description;
        brand.short_description = request.ShortDescription ?? brand.short_description;
        brand.logo_url = request.LogoUrl ?? brand.logo_url;
        brand.banner_url = request.BannerUrl ?? brand.banner_url;
        brand.cover_image_url = request.CoverImageUrl ?? brand.cover_image_url;
        brand.brand_color = request.BrandColor ?? brand.brand_color;
        brand.website_url = request.WebsiteUrl ?? brand.website_url;
        brand.status_id = request.StatusId ?? brand.status_id;
        brand.is_featured = request.IsFeatured;
        brand.is_premium = request.IsPremium;
        brand.updated_at = DateTime.UtcNow;

        await _repository.UpdateAsync(brand);

        return CrmResponse.Updated(new { id = brand.id });
    }
}

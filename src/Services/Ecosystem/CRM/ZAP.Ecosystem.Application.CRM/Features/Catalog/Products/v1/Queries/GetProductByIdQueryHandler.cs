using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Features.Products.v1.DTOs;
using ZAP.Ecosystem.Domain.CRM;
using ProductDto = ZAP.Ecosystem.Application.CRM.Features.Products.v1.DTOs.ProductDto;
using ProductVariantDto = ZAP.Ecosystem.Application.CRM.Features.Products.v1.DTOs.ProductVariantDto;

namespace ZAP.Ecosystem.Application.CRM.Features.Products.v1.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, object>
{
    private readonly IProductRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public GetProductByIdQueryHandler(IProductRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<object> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        if (product == null)
            return CrmResponse.NotFound("Product");

        var localeId = _currentUserService.LocaleId;

        var primaryCategory = product.category_mappings.FirstOrDefault(cm => cm.is_primary) ?? product.category_mappings.FirstOrDefault();

        var productVariants = product.variants.Select(v =>
        {
            var primaryMedia = v.media.FirstOrDefault(m => m.is_primary) ?? v.media.FirstOrDefault();
            return new ProductVariantDto
            {
                id = v.id,
                serial_id = v.serial_id,
                sku_code = v.sku_code,
                barcode = v.barcode,
                variant_name = v.variant_name ?? "",
                base_price = v.base_price,
                sale_price = v.sale_price,
                cost_price = v.cost_price,
                is_active = true,
                media_url = primaryMedia?.media_url,
                qty_on_hand = v.inventory_items.Sum(i => i.qty_on_hand),
                location_count = v.inventory_items.Select(i => i.location_id).Distinct().Count()
            };
        }).ToList();

        var lead = productVariants.FirstOrDefault();

        var dto = new ProductDto
        {
            id = product.id,
            serial_id = product.serial_id,
            product_id = product.id,
            name = product.name,
            tenant_id = product.tenant_id,
            brand_id = product.brand_id,
            product_type_id = product.product_type_id,
            product_type_text = product.product_type?.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name ?? product.product_type?.code ?? "",
            status_id = product.status_id,
            status_name = product.status?.translations?.FirstOrDefault(t => t.locale_id == localeId)?.name ?? product.status?.code ?? "",
            status_code = product.status?.code ?? "",
            category_id = primaryCategory?.category_id,
            category_name = primaryCategory?.category?.name,
            short_description = product.short_description,
            long_description_html = product.long_description_html,
            is_featured = product.is_featured,
            media_url = lead?.media_url,
            variant_name = lead?.variant_name,
            sku_code = lead?.sku_code,
            barcode = lead?.barcode,
            sale_price = lead?.sale_price,
            qty_on_hand = productVariants.Sum(v => v.qty_on_hand),
            created_at = product.created_at,
            updated_at = product.updated_at,
            variants = productVariants
        };

        return CrmResponse.Ok(dto);
    }
}


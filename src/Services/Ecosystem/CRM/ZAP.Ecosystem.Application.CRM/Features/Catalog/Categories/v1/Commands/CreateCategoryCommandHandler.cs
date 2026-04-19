using MediatR;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Categories.v1.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, object>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            id = Guid.NewGuid(),
            parent_id = request.ParentId,
            name = request.Name,
            category_code = request.CategoryCode,
            slug = request.Slug,
            icon_url = request.IconUrl,
            banner_url = request.BannerUrl,
            sort_order = request.SortOrder,
            meta_title = request.MetaTitle,
            meta_description = request.MetaDescription,
            status_id = request.StatusId,
            is_active = request.IsActive,
            seo_title = request.SeoTitle,
            seo_description = request.SeoDescription
        };

        await _repository.CreateAsync(category);

        return CrmResponse.Created(new { id = category.id });
    }
}

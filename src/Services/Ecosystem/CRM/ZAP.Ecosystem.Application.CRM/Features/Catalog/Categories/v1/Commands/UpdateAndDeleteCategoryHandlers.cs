using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ZAP.Ecosystem.Application.CRM.Common;
using ZAP.Ecosystem.Domain.CRM;

namespace ZAP.Ecosystem.Application.CRM.Features.Categories.v1.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, object>
{
    private readonly ICategoryRepository _repository;

    public UpdateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);
        if (category == null)
            return CrmResponse.NotFound("Category");

        if (request.Name != null) category.name = request.Name;
        if (request.ParentId.HasValue) category.parent_id = request.ParentId;
        if (request.CategoryCode != null) category.category_code = request.CategoryCode;
        if (request.Slug != null) category.slug = request.Slug;
        if (request.IconUrl != null) category.icon_url = request.IconUrl;
        if (request.BannerUrl != null) category.banner_url = request.BannerUrl;
        if (request.SortOrder.HasValue) category.sort_order = request.SortOrder.Value;
        if (request.MetaTitle != null) category.meta_title = request.MetaTitle;
        if (request.MetaDescription != null) category.meta_description = request.MetaDescription;
        if (request.StatusId.HasValue) category.status_id = request.StatusId.Value;
        if (request.IsActive.HasValue) category.is_active = request.IsActive.Value;
        if (request.SeoTitle != null) category.seo_title = request.SeoTitle;
        if (request.SeoDescription != null) category.seo_description = request.SeoDescription;

        await _repository.UpdateAsync(category);

        return CrmResponse.Updated(new { id = category.id });
    }
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, object>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);
        if (category == null)
            return CrmResponse.NotFound("Category");

        await _repository.DeleteAsync(request.Id);

        return CrmResponse.Ok(new { id = request.Id }, "Deleted successfully");
    }
}

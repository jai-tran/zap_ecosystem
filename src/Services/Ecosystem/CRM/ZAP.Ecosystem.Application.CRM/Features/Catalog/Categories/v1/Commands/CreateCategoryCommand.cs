using System;
using MediatR;

namespace ZAP.Ecosystem.Application.CRM.Features.Categories.v1.Commands
{
    public class CreateCategoryCommand : IRequest<object>
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CategoryCode { get; set; }
        public string? Slug { get; set; }
        public string? IconUrl { get; set; }
        public string? BannerUrl { get; set; }
        public int? SortOrder { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public int? StatusId { get; set; }
        public bool IsActive { get; set; } = true;
        public string? SeoTitle { get; set; }
        public string? SeoDescription { get; set; }
    }
}

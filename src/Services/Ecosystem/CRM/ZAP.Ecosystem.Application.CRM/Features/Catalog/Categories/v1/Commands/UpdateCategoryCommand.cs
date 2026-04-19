using System;
using MediatR;

namespace ZAP.Ecosystem.Application.CRM.Features.Categories.v1.Commands
{
    public class UpdateCategoryCommand : IRequest<object>
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string? Name { get; set; }
        public string? CategoryCode { get; set; }
        public string? Slug { get; set; }
        public string? IconUrl { get; set; }
        public string? BannerUrl { get; set; }
        public int? SortOrder { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public int? StatusId { get; set; }
        public bool? IsActive { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDescription { get; set; }
    }
}

using MediatR;
using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.Commands;

public class UpdateBrandCommand : IRequest<object>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? BusinessName { get; set; }
    public string? BrandCode { get; set; }
    public string? Slug { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public string? LogoUrl { get; set; }
    public string? BannerUrl { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? BrandColor { get; set; }
    public string? WebsiteUrl { get; set; }
    public int? StatusId { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsPremium { get; set; }
}

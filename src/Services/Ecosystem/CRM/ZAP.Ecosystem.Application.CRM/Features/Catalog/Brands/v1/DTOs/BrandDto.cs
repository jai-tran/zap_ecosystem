using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Brands.v1.DTOs
{
    public class BrandDto
    {
        public Guid id { get; set; }
        public long? serial_id { get; set; }
        public Guid? tenant_id { get; set; }
        public string? brand_code { get; set; }
        public string name { get; set; } = string.Empty;
        public string? business_name { get; set; }
        public string slug { get; set; } = string.Empty;
        public string? description { get; set; }
        public string? short_description { get; set; }
        public string? logo_url { get; set; }
        public string? banner_url { get; set; }
        public string? cover_image_url { get; set; }
        public string? brand_color { get; set; }
        public string? website_url { get; set; }
        public int? status_id { get; set; }
        public string? status_code { get; set; }
        public string? status_name { get; set; }
        public bool is_featured { get; set; }
        public bool is_premium { get; set; }
        public string? display_initial { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}

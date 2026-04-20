using System;

namespace ZAP.Ecosystem.Application.CRM.Features.Locations.v1.DTOs
{
    public class CreateLocationRequestDto
    {
        public string name { get; set; } = string.Empty;
        public string? location_code { get; set; }
        public string? business_name { get; set; }
        public string? description { get; set; }
        public int status_id { get; set; } = 30001; // default active
        public bool is_active { get; set; } = true;
        public int? location_type_id { get; set; }
        public string? address_line_1 { get; set; }
        public string? address_line_2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public int? country_id { get; set; }
        public int? province_id { get; set; }
        public int? district_id { get; set; }
        public int? ward_id { get; set; }
        public string? zipcode { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? website { get; set; }
        public string? logo_url { get; set; }
        public string? cover_image_url { get; set; }
        public string? brand_color { get; set; }
        public string? timezone { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string? operating_hours { get; set; }
        public Guid? parent_location_id { get; set; }
    }

    public class UpdateLocationRequestDto
    {
        public string name { get; set; } = string.Empty;
        public string? location_code { get; set; }
        public string? business_name { get; set; }
        public string? description { get; set; }
        public int status_id { get; set; } = 30001;
        public bool is_active { get; set; } = true;
        public int? location_type_id { get; set; }
        public string? address_line_1 { get; set; }
        public string? address_line_2 { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public int? country_id { get; set; }
        public int? province_id { get; set; }
        public int? district_id { get; set; }
        public int? ward_id { get; set; }
        public string? zipcode { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? website { get; set; }
        public string? logo_url { get; set; }
        public string? cover_image_url { get; set; }
        public string? brand_color { get; set; }
        public string? timezone { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public string? operating_hours { get; set; }
        public Guid? parent_location_id { get; set; }
    }
}

using ZAP.Ecosystem.Domain.CRM.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace ZAP.Ecosystem.Domain.CRM
{
    [Table("brand", Schema = "catalog")]
    public class Brand
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();

        [Column("serial_id")]
        public long? serial_id { get; set; }

        [Column("serial_number")]
        public string? serial_number { get; set; }

        [Column("tenant_id")]
        public Guid? tenant_id { get; set; }

        [Column("brand_code")]
        public string? brand_code { get; set; }

        [Column("legacy_id")]
        public string? legacy_id { get; set; }

        [Column("reference_id")]
        public string? reference_id { get; set; }

        [Column("name")]
        public string name { get; set; } = string.Empty;

        [Column("business_name")]
        public string? business_name { get; set; }

        [Column("slug")]
        public string slug { get; set; } = string.Empty;

        [Column("description")]
        public string? description { get; set; }

        [Column("short_description")]
        public string? short_description { get; set; }

        [Column("logo_url")]
        public string? logo_url { get; set; }

        [Column("banner_url")]
        public string? banner_url { get; set; }

        [Column("cover_image_url")]
        public string? cover_image_url { get; set; }

        [Column("brand_color")]
        public string? brand_color { get; set; }

        [Column("website_url")]
        public string? website_url { get; set; }

        [Column("landing_page_url")]
        public string? landing_page_url { get; set; }

        [Column("landing_page_locale")]
        public string? landing_page_locale { get; set; }

        [Column("social_links", TypeName = "jsonb")]
        public JsonDocument? social_links { get; set; }

        [Column("billing_setting_key")]
        public string? billing_setting_key { get; set; }

        [Column("billing_currency")]
        public string? billing_currency { get; set; }

        [Column("billing_settings", TypeName = "jsonb")]
        public JsonDocument? billing_settings { get; set; }

        [Column("tax_form_type")]
        public string? tax_form_type { get; set; }

        [Column("tax_id")]
        public string? tax_id { get; set; }

        [Column("display_settings", TypeName = "jsonb")]
        public JsonDocument? display_settings { get; set; }

        [Column("meta_title")]
        public string? meta_title { get; set; }

        [Column("meta_description")]
        public string? meta_description { get; set; }

        [Column("meta_keywords", TypeName = "jsonb")]
        public JsonDocument? meta_keywords { get; set; }

        [Column("canonical_url")]
        public string? canonical_url { get; set; }

        [Column("seo_metadata")]
        public string? seo_metadata { get; set; }

        [Column("status_id")]
        public int? status_id { get; set; }

        [Column("is_featured")]
        public bool is_featured { get; set; }

        [Column("is_premium")]
        public bool is_premium { get; set; }

        [Column("display_initial")]
        public string? display_initial { get; set; }

        [Column("created_at")]
        public DateTime? created_at { get; set; }

        [Column("updated_at")]
        public DateTime? updated_at { get; set; }

        // Navigation
        [ForeignKey("status_id")]
        public StatusItem? status { get; set; }
    }
}

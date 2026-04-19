using ZAP.Ecosystem.Domain.CRM.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Location.Domain.Entities
{
    [Table("product_location_pricing", Schema = "catalog")]
    public class ProductLocationPricing
    {
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.Column("id")]
        public Guid id { get; set; } = Guid.NewGuid();

        [Column("product_variant_id")]
        public Guid product_variant_id { get; set; }
        
        [Column("location_id")]
        public Guid location_id { get; set; }
        
        [Column("sale_price_override")]
        public decimal? sale_price_override { get; set; }
        public bool is_active { get; set; } = true;

        // Navigation
        [ForeignKey("product_variant_id")]
        public ProductVariant? variant { get; set; }
    }
}


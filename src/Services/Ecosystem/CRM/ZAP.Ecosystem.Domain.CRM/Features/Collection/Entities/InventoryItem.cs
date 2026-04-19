using ZAP.Ecosystem.Domain.CRM.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Collection.Domain.Entities
{
    [Table("inventory_item", Schema = "logistics")]
    public class InventoryItem
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; } = Guid.NewGuid();
        
        [Column("product_variant_id")]
        public Guid product_variant_id { get; set; }
        
        [Column("warehouse_id")]
        public Guid location_id { get; set; }
        
        [Column("qty_on_hand")]
        public decimal qty_on_hand { get; set; }

        [ForeignKey("product_variant_id")]
        public ProductVariant? Variant { get; set; }
        [ForeignKey("location_id")]
        public Location? Location { get; set; }
    }
}


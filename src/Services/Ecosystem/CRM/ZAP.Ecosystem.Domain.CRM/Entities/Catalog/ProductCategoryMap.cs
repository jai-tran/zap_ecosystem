using ZAP.Ecosystem.Domain.CRM.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZAP.Ecosystem.Domain.CRM
{
    [Table("product_category_map", Schema = "catalog")]
    public class ProductCategoryMap
    {
        [Column("product_id")]
        public Guid product_id { get; set; }
        
        [Column("category_id")]
        public Guid category_id { get; set; }
        
        [Column("is_primary")]
        public bool is_primary { get; set; } = false;

        // Navigation
        [ForeignKey("product_id")]
        public Product? product { get; set; }
        [ForeignKey("category_id")]
        public Category? category { get; set; }
    }
}



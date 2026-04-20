using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZAP.Ecosystem.Domain.CRM
{
    [Table("product_translation", Schema = "catalog")]
    public class ProductTranslation
    {
        [Key]
        public Guid id { get; set; }

        [Column("product_id")]
        public Guid product_id { get; set; }

        [Column("locale_id")]
        public int locale_id { get; set; }

        [Column("name")]
        public string? name { get; set; }

        [Column("short_description")]
        public string? short_description { get; set; }

        [Column("long_description_html")]
        public string? long_description_html { get; set; }

        [ForeignKey("product_id")]
        public Product? product { get; set; }
    }
}

